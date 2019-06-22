using System;
using System.Collections.Generic;
using System.Text;

namespace d8StacksAndQueue.Classes
{
    class Stack
    {
        public Node Top { get; set; }

        /// <summary>
        /// Constructor to require at least one value. this will ensure not an empty stack. 
        /// </summary>
        /// <param name="value"></param>
        public Stack(int value)
        {
            Node node = new Node(value);

            Top = node;
        }

        /// <summary>
        /// Allows us to create an empty stack
        /// </summary>
        public Stack()
        {

        }

        public void Push(int value)
        {
            Node node = new Node(value);
            node.Next = Top;
            Top = node;
        }

        /// <summary>
        /// Removes the top item from the Stack
        /// </summary>
        /// <returns>the value of the node on top of the stack</returns>
        public int Pop()
        {
            Node temp = Top;
            Top = Top.Next;
            temp.Next = null;
            return temp.Value;
        }

        /// <summary>
        /// returns to us the value of the top node in the stack
        /// </summary>
        /// <returns>the value or an exception of empty node </returns>
        public int Peek()
        {
            try
            {
                return Top.Value;
            }
            catch (NullReferenceException e)
            {

                throw new NullReferenceException("No Node Found");
            }

        }
    }
}
