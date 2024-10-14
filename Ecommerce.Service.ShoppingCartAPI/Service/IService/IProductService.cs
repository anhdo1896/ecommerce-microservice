using Ecommerce.Service.ShoppingCartAPI.Dtos;

namespace Ecommerce.Service.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
