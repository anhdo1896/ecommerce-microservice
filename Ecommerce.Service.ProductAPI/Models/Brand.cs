using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Service.ProductAPI.Models
{
    public class Brand : BaseEntity
    {
      
        [Required]
        public string Name { get; set; }
    }
}
