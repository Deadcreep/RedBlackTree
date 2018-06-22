using System;

namespace RBTree
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
            var temp = tree.GetOrderedValues();
        }
    }    
}
