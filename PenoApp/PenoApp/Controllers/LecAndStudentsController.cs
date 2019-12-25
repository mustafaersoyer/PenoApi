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
    [ApiController]
    public class LecAndStudentsController : ControllerBase
    {
         PenoContext _context = new PenoContext();

        // GET: api/LecAndStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LecAndStudent>>> GetLecAndStudents()
        {
            return await _context.LecAndStudents.ToListAsync();
        }

        // GET: api/LecAndStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LecAndStudent>> GetLecAndStudent(int id)
        {
            var lecAndStudent = await _context.LecAndStudents.FindAsync(id);

            if (lecAndStudent == null)
            {
                return NotFound();
            }

            return lecAndStudent;
        }

        // PUT: api/LecAndStudents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLecAndStudent(int id, LecAndStudent lecAndStudent)
        {
            if (id != lecAndStudent.Id)
            {
                return BadRequest();
            }

            _context.Entry(lecAndStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecAndStudentExists(id))
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

        // POST: api/LecAndStudents
        [HttpPost]
        public async Task<ActionResult<LecAndStudent>> PostLecAndStudent(LecAndStudent lecAndStudent)
        {
            _context.LecAndStudents.Add(lecAndStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLecAndStudent", new { id = lecAndStudent.Id }, lecAndStudent);
        }

        // DELETE: api/LecAndStudents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LecAndStudent>> DeleteLecAndStudent(int id)
        {
            var lecAndStudent = await _context.LecAndStudents.FindAsync(id);
            if (lecAndStudent == null)
            {
                return NotFound();
            }

            _context.LecAndStudents.Remove(lecAndStudent);
            await _context.SaveChangesAsync();

            return lecAndStudent;
        }

        private bool LecAndStudentExists(int id)
        {
            return _context.LecAndStudents.Any(e => e.Id == id);
        }
    }
}
