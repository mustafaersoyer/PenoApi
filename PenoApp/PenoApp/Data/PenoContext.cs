using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PenoApp.Models;

namespace PenoApp.Data
{
    public class PenoContext : DbContext
    {
        public DbSet<Student> Students { set; get; }
        public DbSet<Lecture> Lectures { set; get; }
        public DbSet<LecAndStudent> LecAndStudents { set; get; } 
        public DbSet<Notice> Notices { set; get; }
        public DbSet<Aca> Acas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=PenoApp;Integrated Security=True");
        }
    }
}


    