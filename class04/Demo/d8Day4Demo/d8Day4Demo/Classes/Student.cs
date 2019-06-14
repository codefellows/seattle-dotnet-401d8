using System;
using System.Collections.Generic;
using System.Text;

namespace d8Day4Demo.Classes
{
    class Student
    {
        public Student(string name, int age)
        {
            FirstName = name;
            Age = age;
        }

        public Student()
        {
            FirstName = "N/A";
            Age = 18;
        }

        public Student(int age)
        {
            Age = age;
        }

        // properties 
        public string FirstName { get; set; } = "Sally";

        private int _age; // backing store
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {

                _age = value;
            }
        }

        // behaviors

        /// <summary>
        /// A determination of how far you have to commute to school
        /// </summary>
        /// <param name="milesFromSchool">number of miles you live from the school</param>
        /// <returns>expression of concern</returns>
        public string Commute(int milesFromSchool)
        {
            if(milesFromSchool <= 1)
            {
                return "You live very close!!";
            }

            if(milesFromSchool < 5)
            {
                return "You are kind of close...take the bus!";
            }

            if(milesFromSchool > 5)
            {
                return "You live in a far away land....";
            }

            return "You live 5 miles away!";
        }

        /// <summary>
        /// Calculates the number of miles from the given city
        /// </summary>
        /// <param name="city">The city of source</param>
        /// <returns>number of miles</returns>
        public int Commute(string city, int desiredMiles)
        {
            return 0;
        }

        public string Commute(int desiredMiles, string source)
        {
            return "";
        }

        static public void StaticMethod()
        {
            Console.WriteLine("I'm Static!!");
        }
    }
}
