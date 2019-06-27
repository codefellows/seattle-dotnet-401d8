using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d8EnrollmentDemo.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public ICollection<Transcripts> Transcripts { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }


    }
}
