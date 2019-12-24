﻿using System;
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
            .Single(c => c.No == no & c.Password == pass);

            if (student == null)
            {

                return NoContent();
            }
          
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
