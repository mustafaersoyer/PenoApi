using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenoApp.Models
{
    public class Aca
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Password { set; get; }
        public int No { set; get; }
        public ICollection <Lecture> Lectures { get; set; }
    }


}
