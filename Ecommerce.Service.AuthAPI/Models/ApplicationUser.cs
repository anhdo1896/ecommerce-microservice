using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Service.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
