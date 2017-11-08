using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static Node DetectLoop(Node head)
        {
            // Use runner technique, use two pointers
            // fast pointer increase every 2 node
            // if there is a loop, at one pointer the two pointer would meet again.
            // if there is no loop, at the end the fast pointer would be null;

            Node fastPointer = head;
            Node slowPointer = head;

            // A B C D E C
            // p1 d 
            // p2 d
            bool hasLoop = false;
            while(fastPointer != null && fastPointer.Next != null)
            {
                fastPointer = fastPointer.Next.Next;
                slowPointer = slowPointer.Next;
                
                if(slowPointer == fastPointer) 
                {
                    break;
                }
            }



            return null;
        }

    }

    public class Node
    {
        public int Data;
        public Node Next;
    }
}
