using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Node nodeA = new Node(1);
            nodeA.Left = new Node(0);
            nodeA.Left.Left = new Node(0);
            nodeA.Left.Left.Left = new Node(0);
            nodeA.Left.Left.Right = new Node(1);
            nodeA.Left.Right = new Node(1);
            nodeA.Left.Right.Right = new Node(1);
            nodeA.Left.Right.Right.Left = new Node(0);
            int total = CountSumLeftToPath(nodeA);
            Console.WriteLine(total);    
        }

        public static int CountSumLeftToPath(Node root)
        {
            // We need to traverse the tree from root to bottom in a pre-order way 
            // Append the value of each node into a string
            // When reach the bottom, add the whole string into the result list
            
            // We need a list to store all the string
            // Need a helper function to traverse the tree
            //      The function will have root as param, current binaryString, list of all strings
            //          base case: if the root is null,
                            // and the binaryString is not empty, add it to the result lit
            //          if the root is not null
            //              We call the function recurively with root.left, binaryString + root value, result list
            //              we do the same for the right child

            // once done with this function 
            // convert those binary string into decimal base and take sum

            // Time complexity is O(N)
            // Space complexity is O(2^n)


            List<string> binaryNumbers = new List<string>();
            InOrderTraverse(root, "", binaryNumbers);
            int total = 0;
            foreach(string binaryNumber in binaryNumbers)
            {
                int decimalValue = ConvertToDecimal(binaryNumber);
                Console.WriteLine(binaryNumber + ", decimal: " + total);
                total+= decimalValue;
            }

            return total;
        }
        public static int ConvertToDecimal(string binaryString)
        {
            // 1001
            // we start from the right most letter
            // we have a power number, start at 0
            // each time calculate the current value, add it to the total sum
            // increase the power number and move one letter to the left
            int total = 0;
            int power = 0;

            // 1000
            // i = 3, total = 0
            // i = 2, total = 0
            // i = 1, total = 0
            // i = 0, 1*2^3 = 8
            for(int i = binaryString.Length - 1; i >= 0; i--)
            {
                Console.WriteLine("Current Power: " + Math.Pow(2, power));
                Console.WriteLine("Current Position Value:" + binaryString[i].ToString() + " Convert Value:" + Int32.Parse(binaryString[i].ToString()));
                int value = Int32.Parse(binaryString[i].ToString()) * (int) Math.Pow(2, power++); 
                Console.WriteLine("Value = " + value);
                total += value;
            }
           
            return total;
        }
        public static void InOrderTraverse(Node root, string binaryString, List<string> binaryNumbers) 
        {
            if (root != null && root.Left == null && root.Right == null)
            {
                if (!String.IsNullOrEmpty(binaryString)) 
                {
                    binaryNumbers.Add(binaryString + root.Key);
                }
            }
            else if ( root != null)
            {
                if (root.Left != null)
                    InOrderTraverse(root.Left, binaryString + root.Key, binaryNumbers);
                if (root.Right != null)
                    InOrderTraverse(root.Right, binaryString + root.Key, binaryNumbers);
            }
        }
    }

    public class Node{
        public int Key {get;set;}
        public Node Left {get; set;}
        public Node Right {get;set;}
        
        public Node(int key)
        {
            this.Key = key;
            this.Left = null;
            this.Right = null;
        }
    }
}
