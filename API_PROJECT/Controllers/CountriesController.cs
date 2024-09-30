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
        public async Task<ActionResult> GetCountries()
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
                return BadRequest(ex.Message);
            }


        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCountries(string id)
        {
            try
            {
                if (_context.countries == null)
                {
                    return NotFound();
                }
                var Countries = await _context.countries.GetById(id);

                if (Countries == null)
                {
                    return NotFound();
                }

                return Ok(Countries);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountries(int id, Countries Countries)
        {
            if (id != Countries.id)
            {
                return BadRequest();
            }

            try
            {
                await _context.countries.Update(Countries);
                _context.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Countries

        [HttpPost]
        public async Task<ActionResult<Countries>> PostCountries(Countries Countries)
        {
            if (_context.countries == null)
            {
                return Problem("Entity set 'AppDbContext.Countries'  is null.");
            }
            try
            {
                await _context.countries.AddNew(Countries);
                _context.save();

                return CreatedAtAction("GetCountries", new { id = Countries.id }, Countries);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountries(string id)
        {
            if (_context.countries == null)
            {
                return NotFound();
            }
            try
            {
                var Countries = await _context.countries.GetById(id);
                if (Countries == null)
                {
                    return NotFound();
                }

                await _context.countries.Remove(Countries);
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
