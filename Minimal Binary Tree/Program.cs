using System;
using System.Diagnostics;
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
            int[] sortedInput = Enumerable.Range(0, 100).ToArray();
            Node root = null;
            Stopwatch sp = new Stopwatch();
            sp.Start();
            root = BuildMinimalBinarySearchTree(root, sortedInput, 0, sortedInput.Length - 1);
            PrintTree(root);
            sp.Stop();
            Console.WriteLine("Elapsed time: "+sp.ElapsedMilliseconds);
            sp.Restart();
            sp.Start();
            Node newRoot = BuildMinimalBST(sortedInput, 0, sortedInput.Length - 1);
            PrintTree(root);
            sp.Stop();
            Console.WriteLine("Elapsed time:" + sp.ElapsedMilliseconds);
        }

        /*
            Since the array is sorted, the midpoint would be the best candidate for root since both subtrees would have
            almost equal length. 
            Check base case
            Insert midpoint into the tree, recursively do it to the left subarray and right subarray
            Time complexity is O(NlogN) since we need to traverse the entire array and we also need to traverse the BST
            for insertion.
         */
        static Node BuildMinimalBinarySearchTree(Node root, int[] sortedInput, int startIndex, int endIndex)
        {
            // a function which take root node, an array, a start index and an end index
            if(startIndex < 0 || endIndex > sortedInput.Length || startIndex > endIndex)
                return root;

            int midPoint = (startIndex + endIndex) / 2;
            root = Insert(root, sortedInput[midPoint]);
            BuildMinimalBinarySearchTree(root, sortedInput, startIndex, midPoint - 1);
            BuildMinimalBinarySearchTree(root, sortedInput, midPoint + 1, endIndex);
            return root;
        }

        static Node BuildMinimalBST(int[] sortedInput, int startIndex, int endIndex)
        {
            // a function which take root node, an array, a start index and an end index
            if(startIndex < 0 || endIndex > sortedInput.Length || startIndex > endIndex)
                return null;

            int midPoint = (startIndex + endIndex) / 2;
            Node root = new Node(sortedInput[midPoint]);
            root.Left = BuildMinimalBST(sortedInput, startIndex, midPoint - 1);
            root.Right = BuildMinimalBST(sortedInput, midPoint + 1, endIndex);
            return root;
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

        // Print tree value in in order traversal
        static void PrintTree(Node root)
        {
            if (root == null)
                return;
            if (root.Left != null)
                PrintTree(root.Left);
            Console.Write(root.Data);
            if (root.Right != null)
                PrintTree(root.Right);
        }
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
