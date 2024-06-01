using BlitzTech.Domain.Interfaces;
using BlitzTech.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq; // Add this using directive
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAllCategoriesAsync()
    {
        IEnumerable<Category> categoriesEnumerable = await _categoryRepository.GetAllCategoriesAsync();
        List<Category> categories = categoriesEnumerable.ToList();
        return Ok(categories);
    }
}
