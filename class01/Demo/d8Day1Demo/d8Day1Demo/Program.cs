using System;

namespace d8Day1Demo
{
    class Program
    {
        // Method Signature
        // static/instance || return type || Name of Method || parameters (with data type)
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // string greeting = CatGreeting("Amanda");
            //Console.WriteLine(greeting);
            //Console.WriteLine("Please Enter Your Name");

            // string answer = Console.ReadLine();
            // Console.WriteLine(CatGreeting(answer));

            //try
            //{
            //    //ExceptionHandlingExample();
            //    MethodA();

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("CAUGHT IN MAIN!");
            //    Console.WriteLine(e.Message);
            //}

            MethodA();


        }

        static string CatGreeting(string name)
        {
            return $"Hello {name}, How are you?";
        }

        static void ExceptionHandlingExample()
        {
            // Index out of Range

            // Divide By Zero

            // Format Exceptions

           // Console.WriteLine("Enter you favorite Number");
            try
            {
                //string answer = Console.ReadLine();
                // prompt a FormatException
              //  int number = Convert.ToInt32(answer);
               // Console.WriteLine($"Your favorite number was {number}");

                // prompt a DivideByZero exception
               int mysteryNumber = 10;
                int divisor = 0;
                Console.Write($"{mysteryNumber} divided by {divisor} equals");
                int quotient = mysteryNumber / divisor;
                Console.WriteLine(quotient);
                Console.WriteLine("Can you see me??");

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Your number was in the wrong format, please use numeric values only");
            } 
            catch(DivideByZeroException e)
            {
                throw;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Generic Error: {e.Message}");
            }
            finally
            {
                Console.WriteLine("WE ARE DONE!");
            }




        }


        static void MethodA()
        {
            try
            {
                Console.WriteLine("I am in A");
                MethodB();
            }
            catch (Exception)
            {
                Console.WriteLine("Caught in A");

                throw;
            }
        }

        static void MethodB()
        {
            try
            {
                Console.WriteLine("I am in B");
                MethodC();
            }
            catch (Exception)
            {
                Console.WriteLine("Caught in B");
                throw;
            }
        }

        static void MethodC()
        {
            Console.WriteLine("I am in C");
            throw (new Exception("I am a C Exception"));
        }
    }
}
