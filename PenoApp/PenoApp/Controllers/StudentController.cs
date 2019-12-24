using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PenoApp.Data;
using PenoApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PenoApp.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        PenoContext _context = new PenoContext();
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            return "asd";
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<Lecture> Get(int id)
        {
            using (var context =new PenoContext())
            {
                var query = (from lec in context.Lectures
                             join las in context.LecAndStudents
                             on lec.Id equals las.LectureId
                             where las.StudentId == id
                             select lec).ToList();
                 return query;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {

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
