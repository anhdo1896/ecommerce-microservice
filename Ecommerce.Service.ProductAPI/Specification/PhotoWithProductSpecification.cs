using Ecommerce.Service.ProductAPI.Models;

namespace Ecommerce.Service.ProductAPI.Specification
{
    public class PhotoWithProductSpecification : BaseSpecification<Photo>
    {
        public PhotoWithProductSpecification(int Id)
        : base(x => x.ProductId == Id)
        {
            AddInclude(x => x.Product);

        }
    }
}
