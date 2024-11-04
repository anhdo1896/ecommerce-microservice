using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Service.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public DateTime DateOfBirth { get; set; }
    
    }
}
