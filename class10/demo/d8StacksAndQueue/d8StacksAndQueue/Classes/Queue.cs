using System;
using System.Collections.Generic;
using System.Text;

namespace d8StacksAndQueue.Classes
{
    class Queue
    {
        public Node Front { get; set; }
        public Node Rear { get; set; }

        /// <summary>
        /// Add at least one value to the queue
        /// </summary>
        /// <param name="value"></param>
        public Queue(int value)
        {
            Node node = new Node(value);
            Front = node;
            Rear = node;
        }

        // nothing is in the queue
        public Queue()
        {

        }

        /// <summary>
        /// Add a value to the queue
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(int value)
        {
            Node node = new Node(value);
            node.Next = Rear;
            Rear = node;
        }

        /// <summary>
        /// Remove an item from the queue
        /// </summary>
        /// <returns></returns>
        public int Dequeue()
        {
            Node temp = Front;
            Front = Front.Next;
            temp.Next = null;
            return temp.Value;
        }

        // return the value of the front item in the queue
        public int Peek()
        {
            try
            {
                return Front.Value;
            }
            catch (NullReferenceException e)
            {

                throw new NullReferenceException("Front not found");
            }
        }
    }
}
