using System;
using System.Collections.Generic;
using System.Text;

namespace d8HashTable.Classes
{
    class Hashtable
    {
        public LinkedList<Node>[] Map { get; set; }

        public Hashtable(int size)
        {
            // instantiate the linkedlist array to the specified size
            Map = new LinkedList<Node>[size];

        }

        public int GetHash(string key)
        {
            int total = 0;
            // add up all char values of the key
            for (int i = 0; i < key.Length; i++)
            {
                total += key[i];
            }
            // multiply by a large prime
            int primeValue = total * 599;

            // divide by the size of the array
            return primeValue % Map.Length;
        }


        public void Add(string key, string value)
        {
            int index = GetHash(key);
            // check if the position is empty
            if(Map[index] != null)
            {
                // add the item to the head if it's not.
                Map[index].AddFirst(new Node(key, value));
            }
            else
            {
                // create a linkedlist in that bucket
                Map[index] = new LinkedList<Node>();
                Map[index].AddFirst(new Node(key, value));
            }            
        }

        // Get
        public string Get(string key)
        {
            int index = GetHash(key);

           var node = Map[index].First;
            while(node != null)
            {
                if (node.Value.Key == key)
                {
                    return node.Value.Value;
                }
            }

            return "";


         // Node value =  Map[index].Find()
        }

        // Contains


    }
}
