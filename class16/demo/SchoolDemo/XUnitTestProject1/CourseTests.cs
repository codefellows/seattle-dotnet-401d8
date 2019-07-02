using Microsoft.EntityFrameworkCore;
using SchoolDemo.Data;
using SchoolDemo.Models;
using SchoolDemo.Models.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class CourseTests
    {
        [Fact]
        public void CanGetCourseProps()
        {
            // Arrange
            Course course = new Course();
            course.CourseCode = "this-is-my-course-code";
            course.Technology = Technology.CSharp;

            // Act
            string courseCode = course.CourseCode;
            Technology tech = course.Technology;

            // Assert
            Assert.Equal("this-is-my-course-code", courseCode);
            Assert.Equal(Technology.CSharp, tech);

        }

        [Fact]
        public void CanSetCourseCode()
        {
            // Arrange
            Course course = new Course();
            course.CourseCode = "this-is-a-test";
            course.CourseCode = "my-new-name";

            Assert.Equal("my-new-name", course.CourseCode);
            
        }

        [Fact]
        public async Task CanCreateCourse()
        {
            DbContextOptions<SchoolDbContext> options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase("CreateCourse").Options;

            using (SchoolDbContext contxt = new SchoolDbContext(options))
            {

                CourseManager cm = new CourseManager(contxt);

                // Arrange
                Course course = new Course
                {
                    CourseCode = "course-Code",
                    Price = 100m,
                    Technology = Technology.Java
                };

                // act
                await cm.CreateCourse(course);

                // Assert
                Assert.NotNull(contxt.Courses.Find(course.ID));
            }
        }
    }
}
