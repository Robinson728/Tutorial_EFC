using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_EFC.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        [ForeignKey("GradeId")]
        public virtual List<Student> StudentDetails { get; set; }
    }
}
