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
        public async Task<ActionResult> GetProducts()
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
                return BadRequest(ex.Message);
            }


        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProducts(string id)
        {
            try
            {
                if (_context.products == null)
                {
                    return NotFound();
                }
                var Products = await _context.products.GetById(id);

                if (Products == null)
                {
                    return NotFound();
                }

                return Ok(Products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(string id, Products Products)
        {
            if (id != Products.strId)
            {
                return BadRequest();
            }

            try
            {
                await _context.products.Update(Products);
                _context.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Products

        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products Products)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'AppDbContext.Products'  is null.");
            }
            try
            {
                await _context.products.AddNew(Products);
                _context.save();

                return CreatedAtAction("GetProducts", new { id = Products.strId }, Products);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(string id)
        {
            if (_context.products == null)
            {
                return NotFound();
            }
            try
            {
                var Products = await _context.products.GetById(id);
                if (Products == null)
                {
                    return NotFound();
                }

                await _context.products.Remove(Products);
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

