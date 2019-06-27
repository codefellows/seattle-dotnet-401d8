using d8EnrollmentDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d8EnrollmentDemo.Data
{
    public class EnrollmentDbContext : DbContext
    {
        public EnrollmentDbContext(DbContextOptions<EnrollmentDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Binding of the Composite Key using FluentAPI
            modelBuilder.Entity<Enrollments>().HasKey(enrollment =>
            new { enrollment.StudentID, enrollment.CourseID });
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollments> CourseEnrollments { get; set; }
        public DbSet<Transcripts> Transcripts { get; set; }




    }
}
