using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PenoApp.Data;
using PenoApp.Models;

namespace PenoApp.Controllers
{
    [Route("api/[controller]")]
    public class AcasController : Controller
    {
        private readonly PenoContext _context = new PenoContext();

    
        // GET: api/Acas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aca>>> GetAcas()
        {
            return await _context.Acas.ToListAsync();
        }

        // GET: api/Acas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aca>> GetAca(int id)
        {
            var aca = await _context.Acas.FindAsync(id);

            if (aca == null)
            {
                return NotFound();
            }

            return aca;
        }

        // PUT: api/Acas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAca(int id, Aca aca)
        {
            if (id != aca.Id)
            {
                return BadRequest();
            }

            _context.Entry(aca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcaExists(id))
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

        // POST: api/Acas
        [HttpPost]
        public async Task<ActionResult<Aca>> PostAca(Aca aca)
        {
            _context.Acas.Add(aca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAca", new { id = aca.Id }, aca);
        }

        // DELETE: api/Acas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aca>> DeleteAca(int id)
        {
            var aca = await _context.Acas.FindAsync(id);
            if (aca == null)
            {
                return NotFound();
            }

            _context.Acas.Remove(aca);
            await _context.SaveChangesAsync();

            return aca;
        }

        private bool AcaExists(int id)
        {
            return _context.Acas.Any(e => e.Id == id);
        }
    }
}
