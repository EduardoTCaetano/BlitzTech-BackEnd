using System.Collections;
using BlitzTech.Model;

namespace BlitzTech.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> DeleteAsync(Guid id);
        Task<Category> InactiveAsync(Guid id);
    }
}