using Ecommerce.Service.ProductAPI.Models;

namespace Ecommerce.Service.ProductAPI.Specification
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpecParams)
        : base(x =>
               (string.IsNullOrEmpty(productSpecParams.Search)
               || x.Name.ToLower().Contains(productSpecParams.Search)) &&
               (!productSpecParams.BrandId.HasValue
               || x.BrandId == productSpecParams.BrandId) &&
               (!productSpecParams.CategoryId.HasValue
               || x.CategoryId == productSpecParams.CategoryId))
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1),
            productSpecParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }
        public ProductsWithTypesAndBrandsSpecification(int id)
        : base(x => x.Id == id)
        {

            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }
    }
    
}
