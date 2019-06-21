using d8Class07Demo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace d8Class07Demo
{
    delegate void MyDelegate();
    delegate bool NumbersDelegate(int n);


    //class MyDelegate
    //{
    //    // method of mymethod
    //}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //  BasicLinq();
            //   MethodCalls();
           // GroupingByExample();
            SetOpertends();
            #region Delegate Example
            // MyDelegate delly = new MyDelegate(MyMethod);
            // delly.Invoke();
            // delly();

            //  MyDelegate del = MyMethod;

            //  PassingADelegate(del);

            // IEnumerable<int> result = GetAllEvenNumbers(new[] { 1, 2, 3, 4, 5, 6, 7 });
            // IEnumerable<int> oddResult = GetAllOddNumbers(new[] { 1, 2, 3, 4, 5, 6, 7 });


            //foreach (int i in result)
            //{
            //    Console.WriteLine(i);
            //}

            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 55, 33, 98 };
            //NumbersDelegate evens = GetAllEven;
            //NumbersDelegate odds = GetAllOdd;

            //IEnumerable<int> evenNumbers = GenerateNumbers(numbers, evens);
            //IEnumerable<int> oddNumbers = GenerateNumbers(numbers, odds);

            //IEnumerable<int> values = GenerateNumbers(numbers, n => n % 2 == 0);
            //IEnumerable<int> values1 = GenerateNumbers(numbers, n => n % 2 != 0);


            //Console.WriteLine("VALUES");

            //foreach (int i in values)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("===========");
            //foreach (int i in values1)
            //{
            //    Console.WriteLine(i);
            //}

            #endregion
        }

        /*
         * Linq Queries consist of 3 distinct Actions
         *  Obtain a data source
         *  Create the query
         *  Execute the query
         */

        static void BasicLinq()
        {
            Person[] persons =
            {
                new Person("Kate", "Austin", 33),
                new Person("Jack", "Shepard", 39),
                new Person("James", "Ford", 19),
                new Person("Ben", "Linus", 23),
                new Person("Hugo", "Reyes", 20),
            };

            /*
             SQL Query:
             SELECT FirstName, LastName --> "projection"
             FROM persons --> "Data source"
             WHERE Age > 21 --> "Filter"
             Order By Age DESC --> "Sorting"
             */

            // LINQ Query
            IEnumerable<Person> query = from p in persons
                                        select p;
            foreach (var item in query)
            {
                Console.WriteLine(item.FirstName);
            }

            // Get only the first and last names of the people

            var onlyFirstAndLastNames = from p in persons
                                        select new { p.FirstName, p.LastName };

            foreach (var item in onlyFirstAndLastNames)
            {
                Console.WriteLine(item.LastName);
            }

            // filtering

            var filter = from person in persons
                         where person.Age > 21
                         select new { person.FirstName, person.LastName };
            Console.WriteLine();
            Console.WriteLine("ONLY OLDER THAN 21");
            foreach (var item in filter)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

            // sorting 
            var sorted = from person in persons
                         where person.Age > 21
                         orderby person.FirstName ascending
                         select new { person.FirstName, person.LastName };

            Console.WriteLine("======");
            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }

        }

        static void MethodCalls()
        {
            // projections are through our selects
            // mapping is through delegates, use lambda expressions/functions

            Person[] persons =
{
                new Person("Kate", "Austin", 33),
                new Person("Jack", "Shepard", 39),
                new Person("James", "Ford", 19),
                new Person("Ben", "Linus", 23),
                new Person("Hugo", "Reyes", 20),
            };

            // linq method call with a select projection
            // LINQ query equivelant see "BasicLINQ" examples
            var query = persons.Select(p => new { p.FirstName, p.LastName });

            foreach (var item in query)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");

            }

            var chaining = persons.Where(person => person.Age > 21)
                                   .Select(peep => new { peep.FirstName, peep.LastName });

            var orderingItems = persons
                                .Where(person => person.Age > 21)
                                .OrderByDescending(person => person.Age);
            foreach (var item in orderingItems)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Age}");



                // Some actions can only be done through method syntax
                var example = persons
                              .Where(person => person.Age > 21)
                              .OrderByDescending(peep => peep.Age)
                              .Skip(2)
                              .Take(1)
                              .Select(person => new { person.FirstName, person.LastName });

                // LINQ Query equivelant ^^
                var example2 = (from person in persons
                                where person.Age > 21
                                orderby person.Age descending
                                select new
                                {
                                    person.FirstName,
                                    person.LastName
                                })
                               .Skip(2)
                               .Take(1);
            }
        }


        static void GroupingByExample()
        {
            var words = new[] { "cat", "dog", "coffee", "phone", "apple", "marker", "clock" };

            var query = from word in words
                        group word by word.Length;

            var query2 = words.GroupBy(word => word.Length);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var it in item)
                {
                    Console.WriteLine($"* {it}");
                }
            }

        }

        static void SetOpertends()
        {
            var list1 = new[] { 1, 2, 3 };
            var list2 = new[] { 4, 5, 6 };

            // union means items that exist in both sets
            var union = list1.Union(list2); // {1,2,3,4,5,6}

            var list3 = new[] { 1, 2, 3 };
            var list4 = new[] { 3, 5, 6 };

            // things that appear in both collections 
            var intersection = list3.Intersect(list4);

            var list = new[] { 4, 8, 15, 16, 23, 42, 42, 42, 1, 4, 6, 2, 2, 8, 15, 16 };

            var distinct = list.Distinct();

            


        }

        static void MyMethod()
        {
            Console.WriteLine("I am in the method!");
        }

        static void PassingADelegate(MyDelegate candy)
        {
            candy();
        }

        static IEnumerable<int> GetAllEvenNumbers(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }

        }


        static IEnumerable<int> GetAllOddNumbers(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number % 2 != 0)
                {
                    yield return number;
                }
            }

        }

        static IEnumerable<int> GenerateNumbers(IEnumerable<int> numbers, NumbersDelegate action)
        {
            foreach (int number in numbers)
            {
                if (action(number))
                {
                    yield return number;
                }
            }

        }

        static bool GetAllEven(int n) => (n % 2 == 0);


        static bool GetAllOdd(int n)
        {
            return (n % 2 != 0);
        }

        // Func
        Func<int, int, bool> myfunc = ThisTakesInTwoIntsAsArguementsAndReturnsABool;

        static bool ThisTakesInTwoIntsAsArguementsAndReturnsABool(int a, int b)
        {
            return true;
        }


        // action
        Action<int, string, int> myAction = ThisTakesInAnIntStringAndIntWithVoidReturn;

        static void ThisTakesInAnIntStringAndIntWithVoidReturn(int a, string b, int c)
        {

        }

    }



}
