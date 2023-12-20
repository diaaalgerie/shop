using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {


        private readonly ApplicationDbContext _context;

        public AdminsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            if (_context.admins == null)
            {
                return NotFound();
            }
            var admins = await _context.admins.ToListAsync();
            return Ok(admins);
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync(Admin admin)
        {
            _context.admins.Add(admin);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_context.admins == null)
            {
                return NotFound();
            }

            var movie = await _context.admins.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.admins.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminExists(long id)
        {
            return (_context.admins?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
