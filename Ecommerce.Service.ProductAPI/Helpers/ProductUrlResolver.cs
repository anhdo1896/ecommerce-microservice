using AutoMapper;
using Ecommerce.Service.ProductAPI.Dtos;
using Ecommerce.Service.ProductAPI.Models;

namespace Ecommerce.Service.ProductAPI.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;

        }

        public string Resolve(Product source, ProductDto destination,
        string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Image))
            {
                return _config["ApiUrl"] + source.Image;
            }
            return null;
        }
    }
}
