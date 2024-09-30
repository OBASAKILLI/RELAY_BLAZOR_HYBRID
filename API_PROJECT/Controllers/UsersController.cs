using API_PROJECT.Interfaces;
using API_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Controllers
{
 
        [Route("api/[controller]")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly IUnitOfWork _context;

            public UsersController(IUnitOfWork context)
            {
                _context = context;
            }

            // GET: api/Users
            [HttpGet]
            public async Task<ActionResult> GetUsers()
            {
                try
                {
                    var Users = await _context.users.GetAll();

                    if (Users == null || !Users.Any())
                    {
                        return NoContent();
                    }

                    return Ok(Users);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


            }

            // GET: api/Users/5
            [HttpGet("{id}")]
            public async Task<ActionResult> GetUsers(string id)
            {
                try
                {
                    if (_context.users == null)
                    {
                        return NotFound();
                    }
                    var Users = await _context.users.GetById(id);

                    if (Users == null)
                    {
                        return NotFound();
                    }

                    return Ok(Users);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

            // PUT: api/Users/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutUsers(string id, Users Users)
            {
                if (id != Users.strId)
                {
                    return BadRequest();
                }

                try
                {
                    await _context.users.Update(Users);
                    _context.save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest();
                }

                return NoContent();
            }

            // POST: api/Users

            [HttpPost]
            public async Task<ActionResult<Users>> PostUsers(Users Users)
            {
                if (_context.users == null)
                {
                    return Problem("Entity set 'AppDbContext.Users'  is null.");
                }
                try
                {
                    await _context.users.AddNew(Users);
                    _context.save();

                    return CreatedAtAction("GetUsers", new { id = Users.strId }, Users);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

            }

            // DELETE: api/Users/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUsers(string id)
            {
                if (_context.users == null)
                {
                    return NotFound();
                }
                try
                {
                    var Users = await _context.users.GetById(id);
                    if (Users == null)
                    {
                        return NotFound();
                    }

                    await _context.users.Remove(Users);
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