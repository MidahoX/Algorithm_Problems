using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // Use Runner Technique.
        public static bool IsPalindrome(Node head)
        {
            Node fastPointer = head;
            Node slowPointer = head;

            Stack<char> stack = new Stack<char>();

            while(fastPointer != null && fastPointer.Next != null){
                stack.Push(slowPointer.Data);
                fastPointer = fastPointer.Next.Next;
                slowPointer = slowPointer.Next;
            }

            // The list has odd length, skip the middle
            if(fastPointer != null)
                slowPointer = slowPointer.Next;
            
            while(slowPointer != null)
            {
                if(stack.Peek() != slowPointer.Data)
                    return false;
                stack.Pop();
                slowPointer = slowPointer.Next;
            }

            return true;
        }
    }

    public class Node
    {
        public char Data;
        public Node Next;
    }
}
