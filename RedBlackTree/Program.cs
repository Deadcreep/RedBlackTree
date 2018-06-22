using System;

namespace RedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(-1);
            tree.Insert(11);
            tree.Insert(6);
            
           

        }
    }

    class RB
    {

        private Node root;

        public RB() { }

       
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }
            if (root != null)
            {
                InOrderDisplay(root);
            }
        }

        private void InOrderDisplay(Node current)
        {
            if (current != null)
            {
                InOrderDisplay(current.left);
                Console.Write("({0}) ", current.value);
                InOrderDisplay(current.right);
            }
        }
    }
}
