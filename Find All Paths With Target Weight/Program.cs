using System;
using System.Collections.Generic;

namespace Find_All_Paths_With_Target_Weight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Node root = SetUpTestCase();
            List<string> currentPath = new List<string>();
            List<string> allPaths = new List<string>();
            FindPathsWithWeight(root, 619, currentPath, allPaths);
            foreach(var path in allPaths)
            {
                Console.WriteLine(path);
            }

        }

        // Need to keep track of the remaining weight
        // need to keep track of the current path
        // need to keep track of all the paths

        // we recursive traverse down, 
        //      each time we add the node name into the current path.
        //      each time we subtract the tree value from the remaining weight
        // wehn the node is null, don't do anything
        // when we encounter the leaf, we check if the remaining weight is equal to the leaf value
        //      if it is, add the path to all paths
        // when it is not a leaf, then we recursive call the function with the left subtree and the right subtree
        static void FindPathsWithWeight(Node node, int remainingWeight, List<string> currentPath, List<string> allPaths)
        {
            if (node == null)
            {

            }
            else
            {
                remainingWeight -= node.Value;
                currentPath.Add(node.Name);
                if (node.Left == null && node.Right == null)
                {
                    if (remainingWeight == 0)
                    {
                        allPaths.Add(string.Join(",", currentPath));
                    }
                }
                else
                {
                    FindPathsWithWeight(node.Left, remainingWeight, new List<string>(currentPath), allPaths);
                    FindPathsWithWeight(node.Right, remainingWeight, new List<string>(currentPath), allPaths);
                }
            }
        }

        static Node SetUpTestCase()
        {
            Node nodeA = new Node("A", 314);
            nodeA.Left = new Node("B", 6);
            nodeA.Left.Left = new Node("C", 271);
            nodeA.Left.Left.Left = new Node("D", 28);
            nodeA.Left.Left.Right = new Node("E", 0);
            nodeA.Left.Right = new Node("F", 561);
            nodeA.Left.Right.Right = new Node("G", 3);
            nodeA.Left.Right.Right.Left = new Node("H", 17);
            nodeA.Right = new Node("I", 6);
            nodeA.Right.Left = new Node("J", 2);
            nodeA.Right.Left.Right = new Node("K", 1);
            nodeA.Right.Left.Right.Left = new Node("L", 401);
            nodeA.Right.Left.Right.Left.Right = new Node("M", 641);
            nodeA.Right.Left.Right.Right = new Node("N", 257);
            nodeA.Right.Right = new Node("O", 271);
            nodeA.Right.Right.Right = new Node("P", 28);
            return nodeA;
        }
    }

    class Node
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
