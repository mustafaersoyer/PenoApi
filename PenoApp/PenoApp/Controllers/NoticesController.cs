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
    public class NoticesController : ControllerBase
    {
        readonly PenoContext _context = new PenoContext();

        // GET: api/Notices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notice>>> GetNotices()
        {
            return await _context.Notices.ToListAsync();
        }

        // GET: api/Notices/5
        [HttpGet("{id}")]
        public List<Notice> GetNotice(int id)
        {
            //var notice = await _context.Notices.FindAsync(id);
            var customers = _context.Notices
        .Where(c => c.LectureId == id).ToList();

            /*if (customers == null)
            {
                return NotFound();
            }*/

            return customers;
        }

        // PUT: api/Notices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotice(int id, Notice notice)
        {
            if (id != notice.Id)
            {
                return BadRequest();
            }

            _context.Entry(notice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoticeExists(id))
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

        // POST: api/Notices
        [HttpPost]
        public async Task<ActionResult<Notice>> PostNotice([FromBody] Notice notice)
        {
            _context.Notices.Add(notice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotice", new { id = notice.Id }, notice);
        }

        // DELETE: api/Notices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notice>> DeleteNotice(int id)
        {
            var notice = await _context.Notices.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }

            _context.Notices.Remove(notice);
            await _context.SaveChangesAsync();

            return notice;
        }

        private bool NoticeExists(int id)
        {
            return _context.Notices.Any(e => e.Id == id);
        }
    }
}
