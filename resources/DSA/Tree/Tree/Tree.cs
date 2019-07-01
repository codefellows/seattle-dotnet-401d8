using System;
using System.Collections.Generic;

namespace Tree
{
    public class Tree
    {
        public Node Root { get; set; }

        public Tree(Node node)
        {
            Root = node;
        }
        public List<int> PreOrder(Node node)
        {
            List<int> traversal = new List<int>();
            PreOrder(node, traversal);
            return traversal;

        }

        public void PreOrder(Node node, List<int> traversal)
        {
            traversal.Add((int)node.Value);

            if (node.LeftChild != null)
            {
                PreOrder(node.LeftChild, traversal);
            }

            if (node.RightChild != null)
            {
                PreOrder(node.RightChild, traversal);
            }
        }

        public List<int> InOrder(Node node)
        {

            List<int> traversal = new List<int>();
            InOrder(node, traversal);
            return traversal;

        }

        public void InOrder(Node node, List<int> traversal)
        {
            if (node.LeftChild != null)
            {
                InOrder(node.LeftChild, traversal);
            }

            traversal.Add((int)node.Value);

            if (node.RightChild != null)
            {
                InOrder(node.RightChild, traversal);
            }
        }

        public List<int> PostOrder(Node node)
        {
            List<int> traversal = new List<int>();
            PostOrder(node, traversal);
            return traversal;
        }

        public void PostOrder(Node node, List<int> traversal)
        {

            if (node.LeftChild != null)
            {
                PostOrder(node.LeftChild, traversal);
            }

            if (node.RightChild != null)
            {
                PostOrder(node.RightChild, traversal);
            }

            traversal.Add((int)node.Value);
        }

        public void BreadthFirst(Node root)
        {
            Queue<Node> breadth = new Queue<Node>();

            breadth.Enqueue(root);

            while (breadth.TryPeek(out root))
            {
                Node front = breadth.Dequeue();
                Console.Write(front.Value);

                if (front.LeftChild != null)
                {
                    breadth.Enqueue(front.LeftChild);
                }

                if (front.RightChild != null)
                {
                    breadth.Enqueue(front.RightChild);
                }

            }
        }

    }
}
