using Newtonsoft.Json;

namespace Ecommerce.Service.AuthAPI.Dtos
{
    public class UserDto
    { 
        public string ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }

        [JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy")]
        public DateTime? DateOfBirth { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
