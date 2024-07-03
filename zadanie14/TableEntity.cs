using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie14
{
   public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Ocenka> Marks { get; set; }
    }
    public class Ocenka
    {
        public int Id { get; set; }
        public int Ball { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
