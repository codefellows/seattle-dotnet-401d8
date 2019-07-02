using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolDemo.Models.Interfaces
{
    public interface IStudentManager
    {
        // Create
        Task CreateStudent(Student student);

  
        /// <summary>
        /// Gets the student by a specified ID
        /// </summary>
        /// <param name="id">id of the student</param>
        /// <returns>the student object requested</returns>
        Task<Student> GetStudentById(int id);

        // GetAll    
        Task<List<Student>> GetStudents();

        // update
        Task UpdateStudent(Student student);

        // delete
        Task DeleteStudent(int id);

        Task<List<Enrollments>> GetStudentEnrollments(int studentID);




    }
}
