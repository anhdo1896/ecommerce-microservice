using Ecommerce.Service.ProductAPI.Helpers;
using Ecommerce.Service.ProductAPI.Models;

namespace Ecommerce.Service.ProductAPI.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public List<IFormFile>? ImagePhotos { get; set; }
        public ICollection<Photo>? Images { get; set; }
        public int? CategoryId{ get; set; }
        public  int? BrandId { get; set; }
        public double? Rating { get; set; }
        public double? PriceBeforeDiscount { get; set; }
        public int? Quantity { get; set; }
        public int? Sold { get; set; }
        public int? View { get; set; }
        public string? PhotoDescription{ get; set; }
    }
}
