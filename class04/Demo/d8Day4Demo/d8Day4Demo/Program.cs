using d8Day4Demo.Classes;
using System;

namespace d8Day4Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StudentExample();
        }

        public void MyMethod()
        {
            Console.WriteLine("HELLO!");
        }

        static void StudentExample()
        {


            int number = 10;
            Student student = new Student("Josie", 8);

            // student.FirstName = "Josie"; // "set" functionality
            Console.WriteLine(student.FirstName); // act of "getting"

            string response = student.Commute(3);
            Console.WriteLine(response);

            Student student2 = new Student();

            student2.FirstName = "Belle";
            student2.Age = 9;


            Console.WriteLine(student2.FirstName);
            Console.WriteLine(student2.Age);
            Console.WriteLine(student2.Commute(16));


            // Creating a new reference to point to an existing object
            Student amanda = student;

            Console.WriteLine("=============");

            Console.WriteLine($"student firstname:{student.FirstName}");
            Console.WriteLine($"amanda firstname:{amanda.FirstName}");


            amanda.FirstName = "Amanda";
            Console.WriteLine("CHANGED amanda's name to amanda");

            Console.WriteLine($"student firstname:{student.FirstName}");
            Console.WriteLine($"amanda firstname:{amanda.FirstName}");


            // moving our reference to another object
            amanda = student2;




        }
    }
}
