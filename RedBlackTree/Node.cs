namespace RedBlackTree
{
    public class Node
    {
        public Color colour;
        public Node left;
        public Node right;
        public Node parent;
        public int value;

        public Node(int data) { this.value = data; }
        public Node(Color colour) { this.colour = colour; }
        public Node(int data, Color colour) { this.value = data; this.colour = colour; }
    }

    public enum Color
    {
        Red,
        Black
    }
}
