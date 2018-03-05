using System;
using System.Collections.Generic;
using System.Text;

namespace InterconvertStringToInt
{
    class Program
    {
        /*
            Build a function to convert from string to integer and from integer to string
            Do this in O(N) time complexity and O(1) space
         */
        static void Main(string[] args)
        {
            List<string> strNumbers = new List<string>() 
            {
                "1", "12", "123", "-1", "-12"
            };

            foreach(string input in strNumbers) 
            {
                int number = StringToInt(input);
                Console.WriteLine($"{input}. number: {number}");
            }

            List<int> iNumbers = new List<int>()
            {
                1, 12, 123, -123, -12, -1
            };

            foreach(int number in iNumbers)
            {
                string sNumber = IntToString(number);
                Console.WriteLine($"{number}. string: {sNumber}");
            }
        }

        // "100" = 1 * 100 + 0 * 10 + 0 * 1
        // Edge case: negative
        // Edge case: empty, string with characters (ignore if assumption that input is always value number)
        // Have a sum to store the final number value
        // Iterate from the back of the string
        // At each index, sum = sum + (current index value * the power of 10 to the index)
        //      111 = 1 * 100 + 1 * 10 + 1 * 0
        // if the index == 0 and it is negative sign, then we * the sum with -1 
        // return the sum
        // O(N) time complexity, O(1) space complexity since only use 1 extra variable
        // If the string large, use long data type
        static int StringToInt(string input)
        {
            int i = input.Length - 1;
            int sum = 0;
            while(i >= 0)
            {
                if ( i == 0 && input[i] == '-')
                {
                    sum = sum * -1;
                }
                else
                {
                    int currentIndexValue = (int) ((int) char.GetNumericValue(input[i]) * Math.Pow(10, input.Length - 1 - i));
                    sum += currentIndexValue;
                }
                i--;
            }

            return sum;
        }

        // Check if the number is negative and store this state before doing the loop. Otherwise it will be lost after division
        // Use a while loop since we don't know the length of the digit string
        // As long as the number is not zero
        //      Get the remainder of division by 10
        //      Put this number into StringBuilder at index 0 (since we are going from the back)
        //      Divide the current number by 10 and stop until the division result is 0
        // Time complexity is length(number)
        // Space complexity is length(number)
        static string IntToString(int number)
        {
            // Edge case: number == 0 -> loop won't work
            if(number == 0)
            {
                return "0";
            }
            bool isNegative = false;
            if(number < 0)
            {
                isNegative = true;
                // convert negative number to positive -> avoid having to do it for each digit value within the convert loop
                number *= -1;
            }
            StringBuilder sb = new StringBuilder();
            while (number != 0)
            {
                int remainder = number % 10;
                sb.Insert(0, remainder);
                number /= 10;
            }

            if(isNegative)
            {
                sb.Insert(0, '-');
            }

            return sb.ToString();
        }
    }
}
