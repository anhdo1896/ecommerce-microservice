using Ecommerce.Service.ShoppingCartAPI.Dtos;

namespace Ecommerce.Service.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
