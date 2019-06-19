using d8LinkedList.Classes;
using System;

namespace d8LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OurLinkedList();
        }

        static void OurLinkedList()
        {
            LList list = new LList(4);

            list.Insert(8);
            list.Insert(15);
            list.Insert(16);
            list.Insert(23);
            list.Insert(42);

            // expected print : 42 => 23 => 16 => 15 => 8 => 4 => null



            list.Print();





        }
    }
}
