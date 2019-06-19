using System;
using d8Class06.Classes;

namespace d8Class06
{
    class Program
    {
        /* Inheritance: Giving the properties and behaviors to it's
         * derived (child) classes from the parent (base)
         * 
         * Abstraction: Ability to consolidate properties and behaviors that may still require additional information. We have "abstract classes" to assist this on a Object Oriented level. 
        
             */
        static void Main(string[] args)
        {
            Polymorphism();
        }

        static void PersonExample()
        {
            Clown pers1 = new Clown();
            Clown p = new Clown();

            Person person = new Clown
            {
                Name = "Meggan",
                Age = 45,
                Height = 63
            };
        }

        static void Polymorphism()
        {
            // Polymorphism: The ability to change properties and behaviors within a class. 

            Clown clown = new Clown();
            Console.WriteLine($" Clowns Say: {clown.Talk()}");

            Lawyer lawyer = new Lawyer();
            Console.WriteLine($"Lawyer Says: { lawyer.Talk()}");

            Bozo bozo = new Bozo();

            Console.WriteLine($"BOZO SAYS: {bozo.Talk()}");

            Person[] myPeeps = { clown, lawyer, bozo };

            for (int i = 0; i < myPeeps.Length; i++)
            {
                if(myPeeps[i] is Clown)
                {
                    Console.WriteLine(clown.Eat());

                }
                else
                {
                    Console.WriteLine("I am not a clown");
                }
            }

            Car car = new Car();

            clown.Drive(car);

        }
    }
}
