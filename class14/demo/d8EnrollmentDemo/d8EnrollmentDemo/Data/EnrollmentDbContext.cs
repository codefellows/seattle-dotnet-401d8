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

            // Seed our data

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    ID = 1,
                    FirstName = "Jack",
                    LastName = "Shepard",
                    Birthdate = new DateTime(1975, 2, 28)
                },
                new Student
                {
                    ID = 2,
                    FirstName = "Kate",
                    LastName = "Austin",
                    Birthdate = new DateTime(1979, 10, 11)
                },
                new Student
                {
                    ID = 3,
                    FirstName = "Hugo",
                    LastName = "Reyes",
                    Birthdate = new DateTime(1974, 11, 5)
                }
                );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    ID = 1,
                    Technology = Technology.DotNet,
                    CourseCode = "dotnet-is-cool",
                    Price = 50m
                },
                new Course
                {
                    ID = 2,
                    Technology = Technology.Java,
                    CourseCode = "java is delicious",
                    Price = 75m
                },

                new Course
                {
                    ID = 3,
                    Technology = Technology.JavaScript,
                    CourseCode = "The Scripting in Java is crazy",
                    Price = 100m
                }
                );
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollments> CourseEnrollments { get; set; }
        public DbSet<Transcripts> Transcripts { get; set; }




    }
}
