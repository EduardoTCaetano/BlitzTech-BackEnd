using BlitzTech.Data.Context;
using BlitzTech.Data.Migrations;
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
            var category = _context.Categories.ToList();
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

    }
}