using Microsoft.EntityFrameworkCore;
using SchoolDemo.Data;
using SchoolDemo.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDemo.Models.Services
{
    public class StudentManager : IStudentManager
    {
        private readonly SchoolDbContext _context;

        public StudentManager(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task CreateStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            Student student = await GetStudentById(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

        }

        public async Task<Student> GetStudentById(int id) => await _context.Students.FindAsync(id);

        public async Task<List<Enrollments>> GetStudentEnrollments(int studentID)
        {
            // Get the student object
            // get the Enrollments associated with the student
            // return  the list of enrollments the student is in.

            var studentEnrollments = await _context.Enrollments
                                             .Where(x => x.StudentID == studentID)
                                             .Include(c => c.Course)
                                             .Include(s => s.Student)
                                             .ThenInclude(s => s.Transcripts)
                                             .ToListAsync();

            return studentEnrollments;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            // Add any changes that have been made
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
