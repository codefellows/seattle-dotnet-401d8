using System;
using System.Collections.Generic;
using System.Text;

namespace d8LinkedList.Classes
{
    class LList
    {
        public Node Head { get; set; }

        public LList()
        {

        }

        public LList(int value)
        {
            // creates the new node to be added to LL
            Node node = new Node(value);
            // set head to start it out
            Head = node;
        }

        /// <summary>
        /// Insert a new item to the front of a linked list
        /// </summary>
        /// <param name="value">value of the new node</param>
        public void Insert(int value)
        {
            // Create the new Node that will be added
            Node node = new Node(value);
            //set the next reference to point to head
            node.Next = Head;
            // move head
            Head = node;

        }
        /// <summary>
        /// Print out each of hte values inside the LL
        /// </summary>
        public void Print()
        {
            Node current = Head;

            while (current != null)
            {
                Console.Write($"{current.Value} =>");
                current = current.Next;
            }

            Console.WriteLine("null");

         }
    }

}
