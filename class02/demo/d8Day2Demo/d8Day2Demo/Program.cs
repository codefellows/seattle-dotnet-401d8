using System;

namespace d8Day2Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IterateAnArray(5, 100);



        }

        /// <summary>
        ///  Traverse through a new int array full of random integers 
        /// and outputs each value to the console. 
        /// </summary>
        /// <param name="number"> a non negative number to sest the size of the integer array that is created</param>
        /// <param name="maxRandomNumber">the max value of the random numbers inside the array</param>
        public static void IterateAnArray(int number, int maxRandomNumber)
        {
            // Issue #1759 : generating random array numbers
            #region Random Number Generator
            if (number > 0)
            {
                int[] myArray = new int[number];

                // Amanda - 6.11.19 - Added this for loop per request # 15893
                for (int i = 0; i < myArray.Length; i++)
                {
                    Random random = new Random();
                    int randNumber = random.Next(maxRandomNumber);
                    // Amanda = 6.11.19 - Bug Fix for {this problem state here}
                    myArray[i] = randNumber;
                    Console.WriteLine(myArray[i]);
                }
            }

            #endregion

        }

        public static string FizzBuzz(int number)
        {
            if(number % 15 == 0)
            {
                return "FizzBuzz";
            }
            if (number % 3 == 0)
            {
                return "Fizz";
            }
            
            if (number % 5 == 0)
            {
                return "Buzz";
            }
            return number.ToString();
        }
    }
}
