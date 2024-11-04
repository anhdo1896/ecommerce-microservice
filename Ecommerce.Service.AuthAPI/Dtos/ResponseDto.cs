namespace Ecommerce.Service.AuthAPI.Dtos
{
    public class ResponseDto
    {
        public object? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
        public string type { get; set; } = "";
    }
}
