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
        public async Task<ActionResult<IEnumerable<Ads>>> Getads()
        {
          if (_context.ads == null)
          {
              return NotFound();
          }
            return await _context.ads.GetAll();
        }

        // GET: api/Ads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ads>> GetAds(string id)
        {
          if (_context.ads == null)
          {
              return NotFound();
          }
            var ads = await _context.ads.GetById(id);

            if (ads == null)
            {
                return NotFound();
            }

            return ads;
        }

        // PUT: api/Ads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAds(string id, Ads ads)
        {
            if (id != ads.strId)
            {
                return BadRequest();
            }
          
           

            try
            {
                await _context.ads.Update(ads);
                 _context.save();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return NoContent();
        }

        // POST: api/Ads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ads>> PostAds(Ads ads)
        {
          if (_context.ads == null)
          {
              return Problem("Entity set 'AppDbContext.ads'  is null.");
          }
            await _context.ads.AddNew(ads);
             _context.save();

            return CreatedAtAction("GetAds", new { id = ads.strId }, ads);
        }

        // DELETE: api/Ads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAds(string id)
        {
            if (_context.ads == null)
            {
                return NotFound();
            }
            var ads = await _context.ads.GetById(id);
            if (ads == null)
            {
                return NotFound();
            }

            await _context.ads.Remove(ads);
             _context.save();

            return NoContent();
        }

       
    }
}
