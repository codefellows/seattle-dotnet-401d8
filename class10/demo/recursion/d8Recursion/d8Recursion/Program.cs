using System;

namespace d8Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            // MethodA();
            Console.WriteLine(Fib(9));

        }

        static void Recursion()
        {
            // Recursion is breaking down a problem repetively until it is "solved"
            // Indirect - a method is called that then calls itself
            // Direct - method calls itself directly

            // REQUIRES A BASE CASE!!!!


        }

        /// <summary>
        /// N! Non-recusive approach (Iterative)
        /// 5*4*3*2*1
        /// </summary>

        public static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            long value = 1;
            for (int i = n; i > 0; i--)
            {
                value *= i;
            }

            return value;
        }

        public static long FactorialRec(int n)
        {
            if(n ==0)
            {
                return 1;
            }
            long nValue =  FactorialRec(n - 1);
            return n * nValue;

        }

        /// <summary>
        /// Iterative (non-recursive approach)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fib(int n)
        {
            if(n < 2)
            {
                return n;
            }
            long[] fib = new long[n + 1];
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2]; 
               
            }
            return fib[n];
        }


        public static long Fibonocci(int n)
        {
            if(n ==1 || n==0)
            {
                return n;
            }

            return Fibonocci(n - 2) + Fibonocci(n - 1);
        }
        static void MethodA()
        {
            MethodA();
        }

        static void MethodB()
        {
            MethodC();
            Console.WriteLine("HELLO");
        }
        static void MethodC()
        {
            // do something cool
        }
    }
}
