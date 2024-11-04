using Ecommerce.Service.AuthAPI.Data;
using Ecommerce.Service.AuthAPI.Dtos;
using Ecommerce.Service.AuthAPI.Models;
using Ecommerce.Service.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System;

namespace Ecommerce.Service.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(DataContext db, IJwtTokenGenerator jwtTokenGenerator,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //create role if it does not exist
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;

        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.Email.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }

            //if user was found , Generate JWT Token
            var roles = await _userManager.GetRolesAsync(user);
            var token = "Bearer " + _jwtTokenGenerator.GenerateToken(user, roles);
            var tokenRefresh = "Bearer " + _jwtTokenGenerator.GenerateRefreshToken(user, roles);

            UserDto userDTO = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Roles = roles,
                Address = user.Address,
                Avatar = user.Avatar,
                DateOfBirth= user.DateOfBirth
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDTO,
                Token = token, 
                RefreshToken= tokenRefresh
            };

            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {

            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name != null ? registrationRequestDto.Name : "",
                PhoneNumber = registrationRequestDto.PhoneNumber != null ? registrationRequestDto.PhoneNumber : ""
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return "";

                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception ex)
            {

            }
            return "Error Encountered";
        }

        public  async Task<ApplicationUser> EditUser(UserRequestDto registrationRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == registrationRequestDto.Email.ToLower());


            user.Name = registrationRequestDto.Name != null ? registrationRequestDto.Name : "";
            user.PhoneNumber = registrationRequestDto.PhoneNumber != null ? registrationRequestDto.PhoneNumber : "";
            user.Address = registrationRequestDto.Address != null ? registrationRequestDto.Address : "";
            user.Avatar = registrationRequestDto.AvatarUrl != null ? registrationRequestDto.AvatarUrl : "";
            user.DateOfBirth = (DateTime)registrationRequestDto.DateOfBirth;


            try
            {
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

                   
                    return userToReturn;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<string> ChangePassword (ChangePasswordDto changePassword)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == changePassword.Email.ToLower());

            try
            {
                var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
                if (result.Succeeded)
                {
                  
                    return "";

                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<UserDto> GetUser(string id)
        {
            try
            {

                var user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
                var roles = await _userManager.GetRolesAsync(user);
                UserDto userDTO = new()
                {
                    Email = user.Email,
                    ID = user.Id,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    Roles = roles,
                    Address = user.Address,
                    Avatar = user.Avatar,
                    DateOfBirth= user.DateOfBirth
                };
                return userDTO;

            }
            catch (Exception ex)
            {
            }
            return null;

        }

        public async Task<RefreshResponseDto> Refresh(RefreshTokenRequest refreshTokenRequest)
        {

            ApplicationUser user = new()
            {
                Email = refreshTokenRequest.Email,
                Id = refreshTokenRequest.Id,
                UserName = refreshTokenRequest.Username,
            };
            //if user was found , Generate JWT Token
            var token = "Bearer " + _jwtTokenGenerator.GenerateToken(user, refreshTokenRequest.roles);
            var tokenRefresh = "Bearer " + _jwtTokenGenerator.GenerateRefreshToken(user, refreshTokenRequest.roles);



            RefreshResponseDto loginResponseDto = new RefreshResponseDto()
            {
                Token = token,
                RefreshToken = tokenRefresh
            };

            return loginResponseDto;
        }
    }

}
