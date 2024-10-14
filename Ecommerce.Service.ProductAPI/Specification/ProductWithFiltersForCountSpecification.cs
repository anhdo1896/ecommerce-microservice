using Ecommerce.Service.ProductAPI.Models;

namespace Ecommerce.Service.ProductAPI.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productSpecParams)
        : base(x =>
               (string.IsNullOrEmpty(productSpecParams.Search)
               || x.Name.ToLower().Contains(productSpecParams.Search)) &&
               (!productSpecParams.BrandId.HasValue
               || x.BrandId == productSpecParams.BrandId) &&
               (!productSpecParams.CategoryId.HasValue
               || x.CategoryId == productSpecParams.CategoryId))
        {
        }
    }
}
