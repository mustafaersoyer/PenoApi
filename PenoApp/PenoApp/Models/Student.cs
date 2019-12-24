using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenoApp.Models
{
    public class Student
    {
        public int Id { set; get; }
        public String Name { set; get; }
        public String LastName { set; get; }
        public String Password { set; get; }
        public int No { set; get; }
        public ICollection<LecAndStudent> LecAndStudents { set; get; }

    }
}
