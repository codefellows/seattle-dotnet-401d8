using d8HashTable.Classes;
using System;

namespace d8HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HashExample();
        }

        static void HashExample()
        {
            Hashtable ht = new Hashtable(16);
            ht.Add("Cat", "Josie");
            ht.Add("Kitty", "Belle");

            var value = ht.Get("Kitty");

        }
    }
}
