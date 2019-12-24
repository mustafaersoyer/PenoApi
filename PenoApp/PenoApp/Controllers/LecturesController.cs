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
    [Route("api/[controller]/[action]")]
    
    public class LecturesController : Controller
    {
        PenoContext _context = new PenoContext();

   
        // GET: api/Lectures/GetLectures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lecture>>> GetLectures()
        {
            return await _context.Lectures.ToListAsync();
        }

        /*// GET: api/Lectures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lecture>> GetLecture(int id)
        {
            var lecture = await _context.Lectures.FindAsync(id);

            if (lecture == null)
            {
                return NotFound();
            }

            return lecture;
        }*/

        // GET: api/Lectures/GetLectureByStudentId/5
        [HttpGet("{id}")]
        public IEnumerable<Lecture> GetLectureByStudentId(int id) //Student id
        {
            using (var context = new PenoContext())
            {
                var query = (from lec in context.Lectures
                             join las in context.LecAndStudents
                             on lec.Id equals las.LectureId
                             where las.StudentId == id
                             select lec).ToList();
                return query;
            }
        }

        [HttpGet("{id}")]
        public List<Lecture> GetLectureByAcaId(int id)
        {
            //var notice = await _context.Notices.FindAsync(id);
            var customers = _context.Lectures
        .Where(c => c.AcaId == id).ToList();

            /*if (customers == null)
            {
                return NotFound();
            }*/

            return customers;
        }

        // PUT: api/Lectures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLecture(int id, Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return BadRequest();
            }

            _context.Entry(lecture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureExists(id))
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

        // POST: api/Lectures
        [HttpPost]
        public async Task<ActionResult<Lecture>> PostLecture(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLecture", new { id = lecture.Id }, lecture);
        }

        // DELETE: api/Lectures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lecture>> DeleteLecture(int id)
        {
            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }

            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();

            return lecture;
        }

        private bool LectureExists(int id)
        {
            return _context.Lectures.Any(e => e.Id == id);
        }
    }
}
