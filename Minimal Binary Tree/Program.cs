using System;
using System.Linq;

namespace Minimal_Binary_Tree
{
    class Program
    {
        /*
            Given a sorted array, write an algorithm to generate a binary tree with minimal height
         */
        static void Main(string[] args)
        {
            int[] sortedInput = Enumerable.Range(0, 10).ToArray();
            Node root = null;
            root = BuildMinimalBinarySearchTree(root, sortedInput, 0, 9);
            //PrintTree(root);
        }

        static Node BuildMinimalBinarySearchTree(Node root, int[] sortedInput, int startIndex, int endIndex)
        {
            // a function which take root node, an array, a start index and an end index
            if(startIndex < 0 || endIndex > sortedInput.Length || startIndex > endIndex)
                return root;
            
            if(startIndex == endIndex)
                return Insert(root, sortedInput[startIndex]);
            else {
                int midPoint = (startIndex + endIndex) / 2;
                root = Insert(root, sortedInput[midPoint]);
                BuildMinimalBinarySearchTree(root, sortedInput, startIndex, midPoint - 1);
                BuildMinimalBinarySearchTree(root, sortedInput, midPoint + 1, endIndex);
                return root;
            }
        
        }

        static Node Insert(Node root, int key)
        {
            if(root == null)
                root = new Node(key);
            else if (root.Data >= key)
                root.Left = Insert(root.Left, key);
            else
                root.Right = Insert(root.Right, key);
            return root;
        }

        // static void PrintTree(Node root, bool requireNewLine = true)
        // {
        //     if(root != null)
        //     {
        //         Console.Write(root.Data + (requireNewLine ? Environment.NewLine: ""));
        //         PrintTree(root.Left, false);
        //         Console.Write("      ");
        //         PrintTree(root.Right, false);
        //     }
        // }
    }

    class Node
    {
        public int Data {get;set;}
        public Node Left {get;set;}
        public Node Right {get;set;}
        public Node(int key)
        {
            this.Data = key;
        }
    }
}
