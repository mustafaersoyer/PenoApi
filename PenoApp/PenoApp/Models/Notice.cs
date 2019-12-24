using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenoApp.Models
{
    public class Notice
    {
        public int Id { get; set; }
        public String content { get; set; }
        public int LectureId { get; set; }
    }
}
