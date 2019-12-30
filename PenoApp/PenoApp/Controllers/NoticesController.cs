using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PenoApp.Data;
using PenoApp.Models;
using Remotion.Linq;

namespace PenoApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoticesController : ControllerBase
    {
        readonly PenoContext _context = new PenoContext();

        // GET: api/Notices
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Notice>>> GetNotices()
        {
            return await _context.Notices.ToListAsync();
        }*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoticeQueryModel>>> GetNotices()
        {
            var query = (from not in _context.Notices
                         join lec in _context.Lectures
                         on not.LectureId equals lec.Id
                         select (new NoticeQueryModel()
                         {
                             NoticeContent = not.content,
                             LectureName = lec.Name,
                             NoticeTitle = not.title
                         }))
                           .ToList();
            return query;
        }
    


        // GET: api/Notices/5
        [HttpGet("{id}")]
        public List<Notice> GetNotice(int id)//LectureID
        {
            //var notice = await _context.Notices.FindAsync(id);
            var customers = _context.Notices
                            .Where(c => c.LectureId == id).ToList();
            /*var lecturename = _context.Lectures.Select(l=>l.Name).Where(i => i.Id == id).ToList();
            customers += lecturename;*/

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




            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic NWU2NTkyZmEtNTgwMC00ZjY4LThiMGUtMTRiZTI3OTM2ZDkw");

            byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                                    + "\"app_id\": \"e2078391-852d-4b7c-867e-7b20f6c46f23\","
                                                    + "\"contents\": {\"en\": \"'"+notice.title+"'\"},"
                                                    + "\"included_segments\": [\"All\"]}");

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            System.Diagnostics.Debug.WriteLine(responseContent);




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
