using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
   public class Node
    {
        public object Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

	    public Node(int value)
	    {
		    Value = value;
	    }
    }
}
