using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Service.ProductAPI.Models
{
    public class Product : BaseEntity
    { 
      
        [Required]
        public string Name { get; set; }
        [Range(1, 1000)]
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Photo> Images { get; set; }
        public string? Image { get; set; }
        public double? Rating { get; set; }
        public double? PriceBeforeDiscount { get; set; }
        public int? Quantity{ get; set; }
        public int? Sold { get; set; }
        public int? View { get; set; }
       
    }
}
