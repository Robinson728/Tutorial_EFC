using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial_EFC.Models;
using Tutorial_EFC.DAL;
using Microsoft.EntityFrameworkCore;

namespace Tutorial_EFC.BLL
{
    public class StudentBLL
    {
        public static List<Student> GetStudentName(string name)
        {
            var context = new SchoolContext();
            var studentsWithSameName = context.Students.Where(s => s.Name == name).ToList();

            return studentsWithSameName;
        }

        public static Student GetStudentGrade(string name)
        {
            var context = new SchoolContext();

            var studentWithGrade = context.Students.Where(s => s.Name == name).
                Include(s => s.Grade).FirstOrDefault();

            return studentWithGrade;
        }
    }
}
