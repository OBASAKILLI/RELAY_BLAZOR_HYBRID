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
        public async Task<ActionResult> GetSub_Categories()
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
                return BadRequest(ex.Message);
            }


        }

        // GET: api/Sub_Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSub_Categories(string id)
        {
            try
            {
                if (_context.sub_Categories == null)
                {
                    return NotFound();
                }
                var Sub_Categories = await _context.sub_Categories.GetById(id);

                if (Sub_Categories == null)
                {
                    return NotFound();
                }

                return Ok(Sub_Categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Sub_Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSub_Categories(string id, Sub_Categories Sub_Categories)
        {
            if (id != Sub_Categories.strId)
            {
                return BadRequest();
            }

            try
            {
                await _context.sub_Categories.Update(Sub_Categories);
                _context.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Sub_Categories

        [HttpPost]
        public async Task<ActionResult<Sub_Categories>> PostSub_Categories(Sub_Categories Sub_Categories)
        {
            if (_context.sub_Categories == null)
            {
                return Problem("Entity set 'AppDbContext.Sub_Categories'  is null.");
            }
            try
            {
                await _context.sub_Categories.AddNew(Sub_Categories);
                _context.save();

                return CreatedAtAction("GetSub_Categories", new { id = Sub_Categories.strId }, Sub_Categories);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // DELETE: api/Sub_Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSub_Categories(string id)
        {
            if (_context.sub_Categories == null)
            {
                return NotFound();
            }
            try
            {
                var Sub_Categories = await _context.sub_Categories.GetById(id);
                if (Sub_Categories == null)
                {
                    return NotFound();
                }

                await _context.sub_Categories.Remove(Sub_Categories);
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