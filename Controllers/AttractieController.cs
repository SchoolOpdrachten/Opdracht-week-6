using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Opdracht_week_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractieController : ControllerBase
    {
        private readonly PretparkContext _context;

        public AttractieController(PretparkContext context)
        {
            _context = context;
        }

        // GET: api/Attractie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attractie>>> GetAttractie()
        {
          if (_context.Attractie == null)
          {
              return NotFound();
          }
            return await _context.Attractie.ToListAsync();
        }

        // GET: api/Attractie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attractie>> GetAttractie(int id)
        {
          if (_context.Attractie == null)
          {
              return NotFound();
          }
            var attractie = await _context.Attractie.FindAsync(id);

            if (attractie == null)
            {
                return NotFound();
            }

            return attractie;
        }

        // PUT: api/Attractie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttractie(int id, Attractie attractie)
        {
            if (id != attractie.Id)
            {
                return BadRequest();
            }

            _context.Entry(attractie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttractieExists(id))
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

        // POST: api/Attractie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attractie>> PostAttractie(Attractie attractie)
        {
          if (_context.Attractie == null)
          {
              return Problem("Entity set 'PretparkContext.Attractie'  is null.");
          }
            _context.Attractie.Add(attractie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttractie", new { id = attractie.Id }, attractie);
        }

        // DELETE: api/Attractie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttractie(int id)
        {
            if (_context.Attractie == null)
            {
                return NotFound();
            }
            var attractie = await _context.Attractie.FindAsync(id);
            if (attractie == null)
            {
                return NotFound();
            }

            _context.Attractie.Remove(attractie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttractieExists(int id)
        {
            return (_context.Attractie?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        [Route("like/{naam}")]
        public async Task<ActionResult<Attractie>> LikeAttractie(string naam)
        {
            var attractie = await _context.Attractie.FirstOrDefaultAsync(a => a.Naam == naam);
            if (attractie == null)
                return NotFound();
            attractie.AantalLikes++;
            await _context.SaveChangesAsync();
            return attractie;
        }


        [HttpGet]
        [Route("unlike/{naam}")]
        public async Task<ActionResult<Attractie>> UnlikeAttractie(string naam)
        {
            var attractie = await _context.Attractie.SingleOrDefaultAsync(a => a.Naam == naam);
            if (attractie == null)
                return NotFound();
            attractie.AantalLikes--;
            _context.SaveChangesAsync();
            return attractie;
        }
    }
}
