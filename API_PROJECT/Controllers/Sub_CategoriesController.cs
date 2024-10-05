using API_PROJECT.Interfaces;
using API_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Sub_CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public Sub_CategoriesController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Sub_Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sub_Categories>>> GetSub_Categories()
        {
            try
            {
                var Sub_Categories = await _context.sub_Categories.GetAll();

                if (Sub_Categories == null || !Sub_Categories.Any())
                {
                    return NoContent();
                }

                return Ok(Sub_Categories);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the Sub_Categories.");
            }
        }


        // GET: api/Sub_Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSub_Categories(string id)
        {
            try
            {

                var Sub_Categories = await _context.sub_Categories.GetById(id);

                if (Sub_Categories == null)
                {
                    return NotFound();
                }

                return Ok(Sub_Categories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data: " + ex.Message);
            }

        }

        // PUT: api/Sub_Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSub_Categories(string id, [FromBody] Sub_Categories updatedCategory)
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
                await _context.sub_Categories.Update(updatedCategory);
                _context.save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }

            return NoContent();
        }

        // POST: api/Sub_Categories

        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Sub_Categories Sub_Categories)
        {
            if (Sub_Categories == null)
            {
                return BadRequest("Invalid category data.");
            }
            try
            {
                await _context.sub_Categories.AddNew(Sub_Categories);
                _context.save();
                return CreatedAtAction("GetSub_Categories", new { id = Sub_Categories.strId }, Sub_Categories);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data.");

            }

        }

        // DELETE: api/Sub_Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            try
            {
                var existingCategory = await _context.sub_Categories.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                await _context.sub_Categories.Remove(existingCategory);
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
