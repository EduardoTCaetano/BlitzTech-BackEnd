using System.Collections;
using BlitzTech.Model;

namespace BlitzTech.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesasnyc();
        Task<Category> GetByIdasync(Guid id);
        Task<Category> Addasync(Category category);
    }
}