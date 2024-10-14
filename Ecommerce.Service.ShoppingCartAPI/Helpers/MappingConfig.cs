using AutoMapper;
using Ecommerce.Service.ShoppingCartAPI.Dtos;
using Ecommerce.Service.ShoppingCartAPI.Models;

namespace Ecommerce.Service.ShoppingCartAPI.Helpers
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
