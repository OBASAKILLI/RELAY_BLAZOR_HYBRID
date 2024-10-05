using API_PROJECT.Interfaces;
using API_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class Shop_ConnectsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public Shop_ConnectsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Shop_Connects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop_Connects>>> GetShop_Connects()
        {
            try
            {
                var Shop_Connects = await _context.shop_Connects.GetAll();

                if (Shop_Connects == null || !Shop_Connects.Any())
                {
                    return NoContent();
                }

                return Ok(Shop_Connects);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the Shop_Connects.");
            }
        }


        // GET: api/Shop_Connects/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetShop_Connects(string id)
        {
            try
            {

                var Shop_Connects = await _context.shop_Connects.GetById(id);

                if (Shop_Connects == null)
                {
                    return NotFound();
                }

                return Ok(Shop_Connects);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data: " + ex.Message);
            }

        }

        // PUT: api/Shop_Connects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShop_Connects(string id, [FromBody] Shop_Connects updatedCategory)
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
                await _context.shop_Connects.Update(updatedCategory);
                _context.save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }

            return NoContent();
        }

        // POST: api/Shop_Connects

        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Shop_Connects Shop_Connects)
        {
            if (Shop_Connects == null)
            {
                return BadRequest("Invalid category data.");
            }
            try
            {
                await _context.shop_Connects.AddNew(Shop_Connects);
                _context.save();
                return CreatedAtAction("GetShop_Connects", new { id = Shop_Connects.strId }, Shop_Connects);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data.");

            }

        }

        // DELETE: api/Shop_Connects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            try
            {
                var existingCategory = await _context.shop_Connects.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                await _context.shop_Connects.Remove(existingCategory);
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
