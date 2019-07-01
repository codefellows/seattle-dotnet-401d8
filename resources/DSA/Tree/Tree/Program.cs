using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

	        TraversalPractice();


        }

	    static void TraversalPractice()
	    {
		    Node node = new Node(4);
			node.LeftChild = new Node(8);
			node.RightChild = new Node(15);

			node.LeftChild.LeftChild = new Node(16);
			node.LeftChild.RightChild = new Node(23);

			node.RightChild.LeftChild = new Node(42);

			Tree tree = new Tree(node);
			Console.WriteLine();
			Console.WriteLine("PreOrder Traversal:");
			Console.WriteLine(string.Join(',',tree.PreOrder(node)));
            Console.WriteLine();

            Console.WriteLine("InOrder Travesal");
            Console.WriteLine(string.Join(',', tree.InOrder(node)));

            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal");
            Console.WriteLine(string.Join(',', tree.PostOrder(node)));

            Console.WriteLine();

            Console.WriteLine("Breadth First");
            tree.BreadthFirst(node);

        }
    }
}
