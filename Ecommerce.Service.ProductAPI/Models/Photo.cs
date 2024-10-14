namespace Ecommerce.Service.ProductAPI.Models
{
    public class Photo : BaseEntity
    { 
        public string Url { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public Product Product{ get; set; }
        public int ProductId { get; set; }
        public string PublicId { get; set; }
    }
}
