using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenoApp.Models
{
    public class Lecture
    {
        public int Id { set; get; }
        public String Name { set; get; }
        public int AcaId { get; set; }
        public ICollection<LecAndStudent> LecAndStudents{ set; get; }
        public ICollection<Notice> Notices { get; set; }
 
    }
}
