using AutoMapper;
using Ecommerce.Service.ProductAPI.Dtos;
using Ecommerce.Service.ProductAPI.Models;

namespace Ecommerce.Service.ProductAPI.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>()
                .ForMember(d => d.BrandId, o => o.MapFrom(s => s.BrandId))
                .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.CategoryId))
                 .ReverseMap()
                .ForMember(d => d.Images, o => o.MapFrom(s => s.Images))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForAllMembers(opts =>
                {
                    opts.Condition((src, dest, srcMember) => srcMember != null);
                });

            });
            return mappingConfig;
        }
    }
}
