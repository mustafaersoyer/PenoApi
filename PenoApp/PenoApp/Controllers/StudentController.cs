using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PenoApp.Data;
using PenoApp.Models;
using System.IO;
using System.Net;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PenoApp.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        PenoContext _context = new PenoContext();
        // GET: api/<controller>
      

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            return await _context.Students.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("login")]
        public async Task<ActionResult<Student>> Get(int no,string pass)
        {
            var student = _context.Students
            .SingleOrDefault(c => c.No == no & c.Password == pass);

            if (student == null)
            {

                return NotFound();
            }








            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic MjFmODNlZTYtMjI4NS00MmNmLTg5MzQtNGI1NTg2ODdhOTgy");

            byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                                    + "\"app_id\": \"d341be2b-7348-4823-ac1a-422431b33af8\","
                                                    + "\"contents\": {\"en\": \"English Message\"},"
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
















            return student;
            
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody]Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = student.Id }, student);
        }

        // PUT api/<controller>/5
        [HttpPut()]
        public void Put([FromBody]Student value)
        {
            _context.Entry(value).State = EntityState.Added;
            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
