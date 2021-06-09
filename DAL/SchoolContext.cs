using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutorial_EFC.Models;

namespace Tutorial_EFC.DAL
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Api Fluida
            modelBuilder.Entity<Student>()
                    .Property(s => s.StudentId)
                    .HasColumnName("Id")
                    .HasDefaultValue(0)
                    .IsRequired();

            //Relacion de uno a varios
            modelBuilder.Entity<Student>()
                .HasOne<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGradeId);

            //Otra manera -> de varios a uno
            modelBuilder.Entity<Grade>()
                .HasMany<Student>(g => g.Students)
                .WithOne(s => s.Grade)
                .HasForeignKey(s => s.CurrentGradeId);

            //Eliminar en cascada
            modelBuilder.Entity<Grade>()
                .HasMany<Student>(g => g.Students)
                .WithOne(s => s.Grade)
                .HasForeignKey(s => s.CurrentGradeId)
                .OnDelete(DeleteBehavior.Cascade);

            //Relacion de uno a uno
            modelBuilder.Entity<Student>()
                .HasOne<StudentAddress>(s => s.Address)
                .WithOne(ad => ad.Student)
                .HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);
        }
    }
}
