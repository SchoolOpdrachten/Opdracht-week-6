using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Opdracht_week_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PretparkContext _context;

        public AccountController(PretparkContext context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gast>>> GetGast()
        {
          if (_context.Gast == null)
          {
              return NotFound();
          }
            return await _context.Gast.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gast>> GetGast(string id)
        {
          if (_context.Gast == null)
          {
              return NotFound();
          }
            var gast = await _context.Gast.FindAsync(id);

            if (gast == null)
            {
                return NotFound();
            }

            return gast;
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGast(string id, Gast gast)
        {
            if (id != gast.Id)
            {
                return BadRequest();
            }

            _context.Entry(gast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GastExists(id))
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

        // POST: api/Account
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gast>> PostGast(Gast gast)
        {
          if (_context.Gast == null)
          {
              return Problem("Entity set 'PretparkContext.Gast'  is null.");
          }
            _context.Gast.Add(gast);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GastExists(gast.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGast", new { id = gast.Id }, gast);
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGast(string id)
        {
            if (_context.Gast == null)
            {
                return NotFound();
            }
            var gast = await _context.Gast.FindAsync(id);
            if (gast == null)
            {
                return NotFound();
            }

            _context.Gast.Remove(gast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GastExists(string id)
        {
            return (_context.Gast?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
