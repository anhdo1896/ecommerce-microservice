using AutoMapper;
using Ecommerce.Service.CouponAPI.Dtos;
using Ecommerce.Service.CouponAPI.Models;

namespace Ecommerce.Service.CouponAPI.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
