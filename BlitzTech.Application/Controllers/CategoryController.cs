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
            var categoryModel = _context.Categories.ToList()
            .Select(s => s.ToCategoryDto());
            return Ok(categoryModel);
        }

        [HttpGet("{id}")]
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

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto updateDto)
        {
            var categoryModel = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (categoryModel == null)
            {
                return NotFound("Id não encontrado :( ");
            }
            categoryModel.Description = updateDto.Description;
            categoryModel.IsActive = updateDto.IsActive;

            _context.SaveChanges();
            return Ok(categoryModel.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var categoryModel = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (categoryModel == null)
            {
                return NotFound("Id não encontrado :( ");
            }

            _context.Categories.Remove(categoryModel);
            _context.SaveChanges();
            return NoContent();
        }

    }
}