using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenoApp.Models
{
    public class LecAndStudent
    {
        public int Id { set; get; }
        public int LectureId { set; get; }
        public int StudentId { set; get; }
        public Student Student { set; get; }
        public Lecture Lecture { set; get; }
    }
}
