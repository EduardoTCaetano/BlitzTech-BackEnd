using BlitzTech.Model;

namespace BlitzTech.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllCategoriesAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> DeleteAsync(Guid id);
        Task<Product> InactiveAsync(Guid id);
    }
}