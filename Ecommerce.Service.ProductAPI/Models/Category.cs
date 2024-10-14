using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Service.ProductAPI.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
