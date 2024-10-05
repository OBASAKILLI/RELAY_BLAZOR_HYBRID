using API_PROJECT.Interfaces;
using API_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public CategoriesController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            try
            {
                var categories = await _context.categories.GetAll();

                if (categories == null || !categories.Any())
                {
                    return NoContent();
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the categories.");
            }
        }


        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategories(string id)
        {
            try
            {
               
                var Categories = await _context.categories.GetById(id);

                if (Categories == null)
                {
                    return NotFound();
                }

                return Ok(Categories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data: " + ex.Message);
            }

        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(string id, [FromBody] Categories updatedCategory)
        {
            if (updatedCategory == null)
            {
                return BadRequest("Invalid category data.");
            }

            if (id != updatedCategory.strId)
            {
                return BadRequest("Category ID mismatch.");
            }

            try
            {
                await _context.categories.Update(updatedCategory);
                _context.save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }

            return NoContent();
        }

        // POST: api/Categories

        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Categories Categories)
        {
            if (Categories == null)
            {
                return BadRequest("Invalid category data.");
            }
            try
            {
            await _context.categories.AddNew(Categories);
            _context.save();
            return CreatedAtAction("GetCategories", new { id = Categories.strId }, Categories);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data.");

            }

        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            try
            {
                var existingCategory = await _context.categories.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                await _context.categories.Remove(existingCategory);
                _context.save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data: " + ex.Message);
            }
        }
    }

}
