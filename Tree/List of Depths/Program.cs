using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Node treeRoot = new Node(1);
            treeRoot.Left = new Node(2);
            treeRoot.Right = new Node(3);
            treeRoot.Left.Left = new Node(4);
            treeRoot.Left.Left.Left = new Node(5);
            treeRoot.Right.Left = new Node(6);
            
            Dictionary<int, LinkedListNode> map = BuildListOfDepth(treeRoot);
            foreach(var pair in map)
            {
                Console.Write(string.Format("{0}: ", pair.Key));
                LinkedListNode node = pair.Value;
                while (node != null)
                {
                    Console.Write(node.Key + " ");
                    node = node.Next;
                }
                Console.WriteLine();
            }
        }

        public static Dictionary<int, LinkedListNode> BuildListOfDepth(Node root)
        {
            Dictionary<int, LinkedListNode> map = new Dictionary<int, LinkedListNode>();
            BuildListOfDepth(root, 1, map);
            return map;
        }

        public static void BuildListOfDepth(Node root, int depth,  Dictionary<int, LinkedListNode> map)
        {
            if(root == null)
                return;
            
            if(root.Left != null)
                BuildListOfDepth(root.Left, depth + 1, map);

            if(!map.ContainsKey(depth)){
                LinkedListNode head = new LinkedListNode(root.Key);
                map.Add(depth, head);
            } else {
                map[depth].Append(root.Key);
            }

            if(root.Right != null)
                BuildListOfDepth(root.Right, depth + 1, map);
        }

        public Node Insert(Node root, int key)
        {
            if(root == null)
                root = new Node(key);
            else if (root.Key >= key)
                root.Left = Insert(root.Left, key);
            else 
                root.Right = Insert(root.Right, key);
            return root;
        }
    }

    public class Node{
        public int Key {get;set;}
        public Node Left {get;set;}
        public Node Right {get;set;}

        public Node(int key)
        {
            Key = key;
        }
    }

    public class LinkedListNode{
        public int Key {get;set;}
        public LinkedListNode Next {get;set;}

        public LinkedListNode(int key)
        {
            Key = key;
        }

        public void Append(int key)
        {
            if(Next == null)
                Next = new LinkedListNode(key);
            else
                Next.Append(key);
        }

        public LinkedListNode Prepend(int key)
        {
            LinkedListNode newHead = new LinkedListNode(key);
            newHead.Next = this;
            return newHead;
        }
    }

}
