using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace d8EnrollmentDemo.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You need a first name")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name you fool!")]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Required(ErrorMessage ="Everyone gotta Birthday!")]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]


        public DateTime Birthdate { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Transcripts> Transcripts { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }


    }
}
