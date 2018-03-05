using System;
using System.Collections.Generic;

namespace PalindromeChecker
{
    class Program
    {
        /*
            Detect if a string is a palindrome. Do it in O(N) time complexity and O(1) space complexity
         */
        static void Main(string[] args)
        {
            List<string> inputs = new List<string>()
            {
                "",
                "a",
                "ab",
                "abc",
                "aba",
                "abcdedcba"
            };

            foreach(string input in inputs)
            {
                bool isPalindrome = IsPalindrome(input);
                // String interpolation feature in C# 6.0
                Console.WriteLine($"{input} Palindrome: {isPalindrome}");
            }
        }

        /*
            Iterate through the array from 0 -> N/2
            Compare the current index value to the reverting index value
            Return false if there is a miss match
            If there is no miss match, after complete the loop and return true
         */
        static bool IsPalindrome(string input)
        {
            // Edge case: input = ab -> make sure iteration at i = 0 get run (terminate condition)
            for(int i = 0; i < input.Length / 2; i++)
            {
                if (i < input.Length -1 && input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
