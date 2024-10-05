using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PROJECT.Context;
using API_PROJECT.Models;
using API_PROJECT.Interfaces;

namespace API_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public AdsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/Ads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ads>>> GetAds()
        {
            try
            {
                var Ads = await _context.ads.GetAll();

                if (Ads == null || !Ads.Any())
                {
                    return NoContent();
                }

                return Ok(Ads);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the Ads.");
            }
        }


        // GET: api/Ads/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAds(string id)
        {
            try
            {

                var Ads = await _context.ads.GetById(id);

                if (Ads == null)
                {
                    return NotFound();
                }

                return Ok(Ads);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data: " + ex.Message);
            }

        }

        // PUT: api/Ads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAds(string id, [FromBody] Ads updatedCategory)
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
                await _context.ads.Update(updatedCategory);
                _context.save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }

            return NoContent();
        }

        // POST: api/Ads

        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Ads Ads)
        {
            if (Ads == null)
            {
                return BadRequest("Invalid category data.");
            }
            try
            {
                await _context.ads.AddNew(Ads);
                _context.save();
                return CreatedAtAction("GetAds", new { id = Ads.strId }, Ads);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data.");

            }

        }

        // DELETE: api/Ads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            try
            {
                var existingCategory = await _context.ads.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                await _context.ads.Remove(existingCategory);
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
