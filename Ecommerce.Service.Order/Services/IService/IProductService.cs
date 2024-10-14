using Ecommerce.Service.Order.Dtos;

namespace Ecommerce.Service.Order.Services.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
