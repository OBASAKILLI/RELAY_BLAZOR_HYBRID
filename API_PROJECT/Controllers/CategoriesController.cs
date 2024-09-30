using API_PROJECT.Interfaces;
using API_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController:ControllerBase
    {
        private readonly IUnitOfWork _context;

        public CategoriesController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                var Categories = await _context.categories.GetAll();

                if (Categories == null || !Categories.Any())
                {
                    return NoContent();
                }

                return Ok(Categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategories(string id)
        {
            try
            {
                if (_context.categories == null)
                {
                    return NotFound();
                }
                var Categories = await _context.categories.GetById(id);

                if (Categories == null)
                {
                    return NotFound();
                }

                return Ok(Categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(string id, Categories Categories)
        {
            if (id != Categories.strId)
            {
                return BadRequest();
            }

            try
            {
                await _context.categories.Update(Categories);
                _context.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Categories

        [HttpPost]
        public async Task<ActionResult<Categories>> PostCategories(Categories Categories)
        {
            if (_context.categories == null)
            {
                return Problem("Entity set 'AppDbContext.Categories'  is null.");
            }
            try
            {
                await _context.categories.AddNew(Categories);
                _context.save();

                return CreatedAtAction("GetCategories", new { id = Categories.strId }, Categories);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategories(string id)
        {
            if (_context.categories == null)
            {
                return NotFound();
            }
            try
            {
                var Categories = await _context.categories.GetById(id);
                if (Categories == null)
                {
                    return NotFound();
                }

                await _context.categories.Remove(Categories);
                _context.save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();

            }

        }
    }

}
