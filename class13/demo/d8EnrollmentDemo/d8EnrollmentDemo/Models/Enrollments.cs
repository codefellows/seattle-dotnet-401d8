﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace d8EnrollmentDemo.Models
{
    public class Enrollments
    {
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}
