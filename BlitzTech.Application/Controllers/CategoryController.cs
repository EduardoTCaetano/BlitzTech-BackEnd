using BlitzTech.Data.Context;
using BlitzTech.Data.Mapping;
using BlitzTech.Data.Migrations;
using BlitzTech.Domain.Dtos.Category;
using Microsoft.AspNetCore.Mvc;

namespace BlitzTech.Application.Controllers
{
    [Route("API/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var category = _context.Categories.ToList()
            .Select(s => s.ToCategoryDto());
            return Ok(category);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound("Nada encontrado :( ");
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateCategoryRequestDto categoryDto)
        {
            var category = categoryDto.ToCategoryFromCreateDTO();
            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, AutoMapperProfiles.ToCategoryDto(category));
        }
    }
}