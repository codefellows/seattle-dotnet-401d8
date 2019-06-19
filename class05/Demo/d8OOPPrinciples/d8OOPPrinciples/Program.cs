using d8OOPPrinciples.Classes;
using System;

namespace d8OOPPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void PersonExample()
        {
            Instructor instructor = new Instructor();

            instructor.FirstName = "Harry Potter";

            // Since Person is abstract, we cannot instantiate it
           // Person person = new Person();

        }
    }
}
