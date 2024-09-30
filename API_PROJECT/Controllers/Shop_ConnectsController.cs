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
        public async Task<ActionResult> GetShop_Connects()
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
                return BadRequest(ex.Message);
            }


        }

        // GET: api/Shop_Connects/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetShop_Connects(string id)
        {
            try
            {
                if (_context.shop_Connects == null)
                {
                    return NotFound();
                }
                var Shop_Connects = await _context.shop_Connects.GetById(id);

                if (Shop_Connects == null)
                {
                    return NotFound();
                }

                return Ok(Shop_Connects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Shop_Connects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShop_Connects(string id, Shop_Connects Shop_Connects)
        {
            if (id != Shop_Connects.strId)
            {
                return BadRequest();
            }

            try
            {
                await _context.shop_Connects.Update(Shop_Connects);
                _context.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Shop_Connects

        [HttpPost]
        public async Task<ActionResult<Shop_Connects>> PostShop_Connects(Shop_Connects Shop_Connects)
        {
            if (_context.shop_Connects == null)
            {
                return Problem("Entity set 'AppDbContext.Shop_Connects'  is null.");
            }
            try
            {
                await _context.shop_Connects.AddNew(Shop_Connects);
                _context.save();

                return CreatedAtAction("GetShop_Connects", new { id = Shop_Connects.strId }, Shop_Connects);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // DELETE: api/Shop_Connects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop_Connects(string id)
        {
            if (_context.shop_Connects == null)
            {
                return NotFound();
            }
            try
            {
                var Shop_Connects = await _context.shop_Connects.GetById(id);
                if (Shop_Connects == null)
                {
                    return NotFound();
                }

                await _context.shop_Connects.Remove(Shop_Connects);
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


