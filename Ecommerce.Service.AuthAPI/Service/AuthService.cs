using Ecommerce.Service.AuthAPI.Data;
using Ecommerce.Service.AuthAPI.Dtos;
using Ecommerce.Service.AuthAPI.Models;
using Ecommerce.Service.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System;
using Azure;
using Microsoft.IdentityModel.Tokens;

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
            var token =  _jwtTokenGenerator.GenerateToken(user, roles);
            var tokenRefresh = _jwtTokenGenerator.GenerateRefreshToken();

            user.RefreshToken = tokenRefresh;
            user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(15);

            _db.SaveChanges();

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
                PhoneNumber = registrationRequestDto.PhoneNumber != null ? registrationRequestDto.PhoneNumber : "",
                Address = registrationRequestDto.Address != null ? registrationRequestDto.Address : ""
            };

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

        public  async Task<UserDto> EditUser(UserRequestDto registrationRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == registrationRequestDto.Email.ToLower());


            user.Name = registrationRequestDto.Name != null ? registrationRequestDto.Name : "";
            user.PhoneNumber = registrationRequestDto.PhoneNumber != null ? registrationRequestDto.PhoneNumber : "";
            user.Address = registrationRequestDto.Address != null ? registrationRequestDto.Address : "";
            user.Avatar = registrationRequestDto.AvatarUrl != null ? registrationRequestDto.AvatarUrl : "";
            user.DateOfBirth = (DateTime)registrationRequestDto.DateOfBirth;


            
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);
                var roles = await _userManager.GetRolesAsync(userToReturn);
                UserDto userDTO = new()
                {
                    Email = userToReturn.Email,
                    ID = userToReturn.Id,
                    Name = userToReturn.Name,
                    PhoneNumber = userToReturn.PhoneNumber,
                    Roles = roles,
                    Address = userToReturn.Address,
                    Avatar = userToReturn.Avatar,
                    DateOfBirth = userToReturn.DateOfBirth
                };

                return userDTO;

                   

            }
            else
            {
                return null;
            }

           
        }

        public async Task<string> ChangePassword (ChangePasswordDto changePassword)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == changePassword.Email.ToLower());

           
                var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
                if (result.Succeeded)
                {
                    _db.SaveChanges();

                    return "";

                }
                else
                {
                     throw new Exception (result.Errors.FirstOrDefault().Description);
                }

 
        }

        public async Task<UserDto> GetUser(string id)
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

        public async Task<RefreshResponseDto> Refresh(RefreshTokenRequest refreshTokenRequest)
        {

            if (refreshTokenRequest is null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            var principal = _jwtTokenGenerator.GetClaimsPrincipalFromExpriredToken(refreshTokenRequest.AccessToken);
            var username = principal.Claims.Select(x => x.Value).First();

            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == username);
            var roles = await _userManager.GetRolesAsync(user);

            if( user is null || user.RefreshToken != refreshTokenRequest.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new ("Invalid refesh token");
            }

            var newAcessToken = _jwtTokenGenerator.GenerateToken(user,roles);

            return new RefreshResponseDto
            {
                Token = newAcessToken,
            };
        }
    }

}
