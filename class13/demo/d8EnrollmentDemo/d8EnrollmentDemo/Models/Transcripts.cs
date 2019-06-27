using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d8EnrollmentDemo.Models
{
    public class Transcripts
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Grade Grade { get; set; }
        public bool Passed { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }

    public enum Grade
    {
        A = 4,
        B = 3,
        C = 2,
        D = 1
    }
}
