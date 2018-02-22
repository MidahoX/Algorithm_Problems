using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsBST(Node root)
        {
            return IsBST(root, Int32.MinValue, Int32.MaxValue);
        }

        public bool IsBST(Node node, int min, int max)
        {
            if(node == null)
                return true;
            
           if(node.Data < min || node.Data > max)
                return false;
            
            return (IsBST(node.Left, min, node.Data - 1) && IsBST(node.Right, node.Data + 1 , max));
        }

        public Node Insert(Node root, int key)
        {
            if(root == null)
                root = new Node(key);
        }
    }

    public class Node 
    {
        public Node Left {get;set;}
        public Node Right {get;set;}
        public int Data {get;set;}

        public Node(int key)
        {
            Data = key;
        }
    }
}
