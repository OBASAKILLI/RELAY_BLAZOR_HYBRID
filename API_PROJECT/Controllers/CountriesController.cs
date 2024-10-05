using API_PROJECT.Interfaces;
using API_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public CountriesController(IUnitOfWork context)
        {
            _context = context;
        }
        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Countries>>> GetCountries()
        {
            try
            {
                var Countries = await _context.countries.GetAll();

                if (Countries == null || !Countries.Any())
                {
                    return NoContent();
                }

                return Ok(Countries);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the Countries.");
            }
        }


        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCountries(string id)
        {
            try
            {

                var Countries = await _context.countries.GetById(id);

                if (Countries == null)
                {
                    return NotFound();
                }

                return Ok(Countries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data: " + ex.Message);
            }

        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountries(int id, [FromBody] Countries updatedCategory)
        {
            if (updatedCategory == null)
            {
                return BadRequest("Invalid category data.");
            }

            if (id != updatedCategory.id)
            {
                return BadRequest("Category ID mismatch.");
            }

            try
            {
                await _context.countries.Update(updatedCategory);
                _context.save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }

            return NoContent();
        }

        // POST: api/Countries

        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Countries Countries)
        {
            if (Countries == null)
            {
                return BadRequest("Invalid category data.");
            }
            try
            {
                await _context.countries.AddNew(Countries);
                _context.save();
                return CreatedAtAction("GetCountries", new { id = Countries.id }, Countries);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data.");

            }

        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            try
            {
                var existingCategory = await _context.countries.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                await _context.countries.Remove(existingCategory);
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
