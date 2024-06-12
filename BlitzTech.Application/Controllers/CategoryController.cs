using BlitzTech.Data.Context;
using BlitzTech.Data.Mapping;
using BlitzTech.Data.Migrations;
using BlitzTech.Domain.Dtos.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var categoryModel = _context.Categories.ToList()
            .Select(s => s.ToCategoryDto());
            return Ok(categoryModel);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var categoryModel = _context.Categories.Find(id);

            if (categoryModel == null)
            {
                return NotFound("Nada encontrado :( ");
            }

            return Ok(categoryModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryRequestDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromCreateDTO();
            _context.Categories.Add(categoryModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, AutoMapperProfiles.ToCategoryDto(categoryModel));
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto updateDto)
        {
            var categoryModel = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (categoryModel == null)
            {
                return NotFound("Id não encontrado :( ");
            }

            // Update the properties
            categoryModel.Description = updateDto.Description;
            categoryModel.IsActive = updateDto.IsActive;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Categories.Any(e => e.Id == id))
                {
                    return NotFound("Id não encontrado :( ");
                }
                else
                {
                    throw;
                }
            }

            return Ok(categoryModel.ToCategoryDto());
        }
    }
}