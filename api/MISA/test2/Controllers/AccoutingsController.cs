using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test2.Models;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccoutingsController : ControllerBase
    {
        private readonly misaaccoutantContext _context;

        public AccoutingsController(misaaccoutantContext context)
        {
            _context = context;
        }

        // GET: api/Accoutings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accouting>>> GetAccoutings()
        {
            return await _context.Accoutings.ToListAsync();
        }

        // GET: api/Accoutings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accouting>> GetAccouting(Guid id)
        {
            var accouting = await _context.Accoutings.FindAsync(id);

            if (accouting == null)
            {
                return NotFound();
            }

            return accouting;
        }

        // PUT: api/Accoutings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccouting(Guid id, Accouting accouting)
        {
            if (id != accouting.Idaccounting)
            {
                return BadRequest();
            }

            _context.Entry(accouting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccoutingExists(id))
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

        // POST: api/Accoutings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accouting>> PostAccouting(Accouting accouting)
        {
            accouting.Idaccounting = Guid.NewGuid();
            _context.Accoutings.Add(accouting);

            if (AccoutingExists(accouting.Idaccounting))
            {
                return Conflict();
            }
            else {
                await _context.SaveChangesAsync();
            }
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (AccoutingExists(accouting.Idaccounting))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return CreatedAtAction("GetAccouting", new { id = accouting.Idaccounting }, accouting);
        }

        // DELETE: api/Accoutings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccouting(Guid id)
        {
            var accouting = await _context.Accoutings.FindAsync(id);
            if (accouting == null)
            {
                return NotFound();
            }

            _context.Accoutings.Remove(accouting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccoutingExists(Guid id)
        {
            return _context.Accoutings.Any(e => e.Idaccounting == id);
        }
    }
}
