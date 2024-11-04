namespace Ecommerce.Service.ShoppingCartAPI.Dtos
{
    public class Photo
    {
        public string Url { get; set; }
        public string? Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public string PublicId { get; set; }
    }
}
