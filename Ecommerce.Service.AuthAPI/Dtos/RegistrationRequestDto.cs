namespace Ecommerce.Service.AuthAPI.Dtos
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public IFormFile? Avatar { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Role { get; set; }
    }
}
