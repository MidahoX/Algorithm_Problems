using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Node root = SetupTree();
            Console.WriteLine(CheckSymmetry(root));
        }

        public static Node SetupTree()
        {
            Node root = new Node(1);
            root.Left = new Node(2);
            root.Right = new Node(5);
            root.Left.Right = new Node(3);
            root.Right.Left = new Node(3);            
            return root;
        }

        public static bool CheckSymmetry(Node root)
        {
            return IsSymmetric(root.Left, root.Right);
        }

        // use recursive to detect symmetry
        // the tree is symmetric if its left child mirror its right child
        // we traverse down the root, check if its left children mirror its right children
        // base case:
        //      if left node va right node is empty
        //          then symmetric
        //      if one is not empty
        //          then not symmetric
        // recursive case:        
        //      check if the left node key equal to the right node key, then recursive check symmetric the left and right node children
        public static bool IsSymmetric(Node left, Node right)
        {
            if (left == null && right == null)
            {
                return true;
            }
            else if (left == null && right != null || left != null && right == null)
            {
                return false;
            }
            else
            {
                return left.Key == right.Key
                    && IsSymmetric(left.Left, right.Right)
                    && IsSymmetric(left.Right, right.Left);
            }
        }
    }

    public class Node
    {
        public int Key { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int key)
        {
            this.Key = key;
            Left = null;
            Right = null;
        }
    }
}
