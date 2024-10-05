using API_PROJECT.Interfaces;
using API_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public ShopsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shops>>> GetShops()
        {
            try
            {
                var Shops = await _context.shops.GetAll();

                if (Shops == null || !Shops.Any())
                {
                    return NoContent();
                }

                return Ok(Shops);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the Shops.");
            }
        }


        // GET: api/Shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetShops(string id)
        {
            try
            {

                var Shops = await _context.shops.GetById(id);

                if (Shops == null)
                {
                    return NotFound();
                }

                return Ok(Shops);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data: " + ex.Message);
            }

        }

        // PUT: api/Shops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShops(string id, [FromBody] Shops updatedCategory)
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
                await _context.shops.Update(updatedCategory);
                _context.save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }

            return NoContent();
        }

        // POST: api/Shops

        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Shops Shops)
        {
            if (Shops == null)
            {
                return BadRequest("Invalid category data.");
            }
            try
            {
                await _context.shops.AddNew(Shops);
                _context.save();
                return CreatedAtAction("GetShops", new { id = Shops.strId }, Shops);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data.");

            }

        }

        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            try
            {
                var existingCategory = await _context.shops.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                await _context.shops.Remove(existingCategory);
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
