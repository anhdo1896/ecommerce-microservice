namespace Ecommerce.Service.AuthAPI.Dtos
{
    public class RefreshTokenRequest
    {
        public string AccessToken { get; set; }
        public string? RefreshToken { get; set; }
     

    }
}
