namespace Ecommerce.Service.AuthAPI.Dtos
{
    public class RefreshTokenRequest
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> roles { get; set; }

    }
}
