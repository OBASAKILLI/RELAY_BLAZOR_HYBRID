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
        public async Task<ActionResult> GetShops()
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
                return BadRequest(ex.Message);
            }


        }

        // GET: api/Shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetShops(string id)
        {
            try
            {
                if (_context.shops == null)
                {
                    return NotFound();
                }
                var Shops = await _context.shops.GetById(id);

                if (Shops == null)
                {
                    return NotFound();
                }

                return Ok(Shops);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Shops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShops(string id, Shops Shops)
        {
            if (id != Shops.strId)
            {
                return BadRequest();
            }

            try
            {
                await _context.shops.Update(Shops);
                _context.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Shops

        [HttpPost]
        public async Task<ActionResult<Shops>> PostShops(Shops Shops)
        {
            if (_context.shops == null)
            {
                return Problem("Entity set 'AppDbContext.Shops'  is null.");
            }
            try
            {
                await _context.shops.AddNew(Shops);
                _context.save();

                return CreatedAtAction("GetShops", new { id = Shops.strId }, Shops);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShops(string id)
        {
            if (_context.shops == null)
            {
                return NotFound();
            }
            try
            {
                var Shops = await _context.shops.GetById(id);
                if (Shops == null)
                {
                    return NotFound();
                }

                await _context.shops.Remove(Shops);
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


