using System.Collections;
using BlitzTech.Model;

namespace BlitzTech.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetById(Guid id);
    }
}