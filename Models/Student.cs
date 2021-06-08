using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_EFC.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int GradeId { get; set; }
        public object Grade { get; internal set; }
    }
}
