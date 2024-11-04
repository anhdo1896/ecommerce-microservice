namespace Ecommerce.Service.Order.Dtos
{
    public class StripeRequestDto
    {
        public string? StripeSessionUrl { get; set; }
        public string? StripeSessionId { get; set; }
        public string ApprovedUrl { get; set; } = "http://localhost:3000/cart";
        public string CancelUrl { get; set; } = "http://http://localhost:3000/cart";
        public OrderHeaderDto OrderHeader { get; set; }
    }
}
