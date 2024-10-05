using API_PROJECT.Interfaces;
using API_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public ProductsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            try
            {
                var Products = await _context.products.GetAll();

                if (Products == null || !Products.Any())
                {
                    return NoContent();
                }

                return Ok(Products);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the Products.");
            }
        }


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProducts(string id)
        {
            try
            {

                var Products = await _context.products.GetById(id);

                if (Products == null)
                {
                    return NotFound();
                }

                return Ok(Products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data: " + ex.Message);
            }

        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(string id, [FromBody] Products updatedCategory)
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
                await _context.products.Update(updatedCategory);
                _context.save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }

            return NoContent();
        }

        // POST: api/Products

        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Products Products)
        {
            if (Products == null)
            {
                return BadRequest("Invalid category data.");
            }
            try
            {
                await _context.products.AddNew(Products);
                _context.save();
                return CreatedAtAction("GetProducts", new { id = Products.strId }, Products);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data.");

            }

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            try
            {
                var existingCategory = await _context.products.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                await _context.products.Remove(existingCategory);
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
