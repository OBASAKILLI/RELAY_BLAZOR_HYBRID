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
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
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

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the Users.");
            }
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUsers(string id)
        {
            try
            {

                var Users = await _context.users.GetById(id);

                if (Users == null)
                {
                    return NotFound();
                }

                return Ok(Users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data: " + ex.Message);
            }

        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(string id, [FromBody] Users updatedCategory)
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
                await _context.users.Update(updatedCategory);
                _context.save();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }

            return NoContent();
        }

        // POST: api/Users

        [HttpPost]
        public async Task<ActionResult> PostCategory([FromBody] Users Users)
        {
            if (Users == null)
            {
                return BadRequest("Invalid category data.");
            }
            try
            {
                await _context.users.AddNew(Users);
                _context.save();
                return CreatedAtAction("GetUsers", new { id = Users.strId }, Users);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving data.");

            }

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            try
            {
                var existingCategory = await _context.users.GetById(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                await _context.users.Remove(existingCategory);
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
