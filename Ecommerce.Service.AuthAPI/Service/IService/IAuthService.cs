using Ecommerce.Service.AuthAPI.Dtos;
using Ecommerce.Service.AuthAPI.Models;

namespace Ecommerce.Service.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<RefreshResponseDto> Refresh(RefreshTokenRequest loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
        Task<ApplicationUser> EditUser(UserRequestDto registrationRequestDto);
        Task<string> ChangePassword(ChangePasswordDto changePasswordDto);
        Task<UserDto> GetUser(string id);
    }
}
