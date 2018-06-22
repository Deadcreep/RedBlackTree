using System;
using System.Collections.Generic;

namespace RedBlackTree
{
    public class Tree
    {
        private Node root;

        public int Count { get; private set; }
        
        public Tree() {}

        public Tree(int rootValue)
        {
            root = new Node(rootValue, Color.Black);
        }

        private void LeftRotate(Node X)
        {
            Node Y = X.right;
            X.right = Y.left;
            if (Y.left != null)
            {
                Y.left.parent = X;
            }
            if (Y != null)
            {
                Y.parent = X.parent;
            }
            if (X.parent == null)
            {
                root = Y;
            }
            if (X == X.parent.left)
            {
                X.parent.left = Y;
            }
            else
            {
                X.parent.right = Y;
            }
            Y.left = X;
            if (X != null)
            {
                X.parent = Y;
            }

        }

        private void RightRotate(Node Y)
        {

            Node X = Y.left;
            Y.left = X.right;
            if (X.right != null)
            {
                X.right.parent = Y;
            }
            if (X != null)
            {
                X.parent = Y.parent;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            if (Y == Y.parent.right)
            {
                Y.parent.right = X;
            }
            if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }

            X.right = Y;
            if (Y != null)
            {
                Y.parent = X;
            }
        }

        public void Insert(int item)
        {
            Node newItem = new Node(item);
                       
            if (root == null)
            {
                root = newItem;
                root.colour = Color.Black;
                return;
            }

            Node Y = null;
            Node X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.value < X.value)
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }
            newItem.parent = Y;
            if (Y == null)
            {
                root = newItem;
            }
            else if (newItem.value < Y.value)
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }
            newItem.left = null;
            newItem.right = null;
            newItem.colour = Color.Red;
            InsertFixUp(newItem);
            Count++;
        }

        public Node Find(int key)
        {
            bool isFound = false;
            Node temp = root;
            Node item = null;
            while (!isFound)
            {
                if (temp == null)
                {
                    break;
                }
                if (key < temp.value)
                {
                    temp = temp.left;
                }
                if (key > temp.value)
                {
                    temp = temp.right;
                }
                if (key == temp.value)
                {
                    isFound = true;
                    item = temp;
                }
            }
            if (isFound)
            {
                return temp;
            }
            else
            {
                return null;
            }
        }

        private void InsertFixUp(Node item)
        {
            while (item != root && item.parent.colour == Color.Red)
            {
                if (item.parent == item.parent.parent.left)
                {
                    Node Y = item.parent.parent.right;
                    if (Y != null && Y.colour == Color.Red)
                    {
                        item.parent.colour = Color.Black;
                        Y.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        item = item.parent.parent;
                    }
                    else
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        RightRotate(item.parent.parent);
                    }

                }
                else
                {
                    Node X = null;

                    X = item.parent.parent.left;
                    if (X != null && X.colour == Color.Black)
                    {
                        item.parent.colour = Color.Red;
                        X.colour = Color.Red;
                        item.parent.parent.colour = Color.Black;
                        item = item.parent.parent;
                    }
                    else
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        LeftRotate(item.parent.parent);

                    }

                }
                root.colour = Color.Black;
            }
        }

        public void Delete(int key)
        {
            Node item = Find(key);
            Node X = null;
            Node Y = null;

            if (item == null)
            {
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            else if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.value = Y.value;
            }
            if (Y.colour == Color.Black)
            {
                DeleteFixUp(X);
            }
            Count--;
        }

        private void DeleteFixUp(Node X)
        {
            while (X != null && X != root && X.colour == Color.Black)
            {
                if (X == X.parent.left)
                {
                    Node W = X.parent.right;
                    if (W.colour == Color.Red)
                    {
                        W.colour = Color.Black;
                        X.parent.colour = Color.Red;
                        LeftRotate(X.parent);
                        W = X.parent.right;
                    }
                    if (W.left.colour == Color.Black && W.right.colour == Color.Black)
                    {
                        W.colour = Color.Red;
                        X = X.parent;
                    }
                    else if (W.right.colour == Color.Black)
                    {
                        W.left.colour = Color.Black;
                        W.colour = Color.Red;
                        RightRotate(W);
                        W = X.parent.right;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = Color.Black;
                    W.right.colour = Color.Black;
                    LeftRotate(X.parent);
                    X = root;
                }
                else
                {
                    Node W = X.parent.left;
                    if (W.colour == Color.Red)
                    {
                        W.colour = Color.Black;
                        X.parent.colour = Color.Red;
                        RightRotate(X.parent);
                        W = X.parent.left;
                    }
                    if (W.right.colour == Color.Black && W.left.colour == Color.Black)
                    {
                        W.colour = Color.Black;
                        X = X.parent;
                    }
                    else if (W.left.colour == Color.Black)
                    {
                        W.right.colour = Color.Black;
                        W.colour = Color.Red;
                        LeftRotate(W);
                        W = X.parent.left;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = Color.Black;
                    W.left.colour = Color.Black;
                    RightRotate(X.parent);
                    X = root;
                }
            }
            if (X != null)
                X.colour = Color.Black;
        }

        private Node Minimum(Node X)
        {
            while (X.left.left != null)
            {
                X = X.left;
            }
            if (X.left.right != null)
            {
                X = X.left.right;
            }
            return X;
        }

        private Node TreeSuccessor(Node X)
        {
            if (X.left != null)
            {
                return Minimum(X);
            }
            else
            {
                Node Y = X.parent;
                while (Y != null && X == Y.right)
                {
                    X = Y;
                    Y = Y.parent;
                }
                return Y;
            }
        }

        public List<int> BypassTree()
        {
            List<int> values = new List<int>();

            if (root == null)
            {
                return null;
            }
            if (root != null)
            {
                InOrderDisplay(root, values);
            }
            return values;
        }

        private void InOrderDisplay(Node current, List<int> values)
        {
            if (current != null)
            {
                InOrderDisplay(current.left, values);
                values.Add(current.value);
                InOrderDisplay(current.right, values);
            }
        }
    }
}
