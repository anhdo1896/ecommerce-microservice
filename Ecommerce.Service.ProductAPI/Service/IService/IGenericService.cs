using Ecommerce.Service.ProductAPI.Models;
using Ecommerce.Service.ProductAPI.Specification;

namespace Ecommerce.Service.ProductAPI.Service.IService
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetListAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        int Add(T entity);
        int Update(T entity);
        void Delete(T entity);

    }

}
