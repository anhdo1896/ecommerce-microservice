using Newtonsoft.Json;

namespace Ecommerce.Service.AuthAPI.Dtos
{
    public class UserRequestDto
    {
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public IFormFile? Avatar { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Role { get; set; }

        [JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy")]
        public DateTime? DateOfBirth { get; set; }
    }
}
