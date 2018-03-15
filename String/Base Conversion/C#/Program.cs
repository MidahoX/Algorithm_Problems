using System;
using System.Collections.Generic;
using System.Text;

namespace ComputeSpreadsheetColumn
{
    class Program
    {
        /*
            Spreadsheets often use alphabetical encoding of the successive columns. A, B, C,...Z, AA, AB, AC...
            Implement a function that converts a spreadsheet column id to the corresponding integer. 
            Ex: A = 1, Z =26, AA = 27, ZZ = 702...
            How would you test your code?
         */
        static void Main(string[] args)
        {
            List<string> inputs = new List<string>()
            {
                "", "A", "B", "Y","Z","AA", "AB", "ZY", "ZZ"
            };

            foreach(string input in inputs)
            {
                int iValue = ConvertColumnStringToInt(input);
                Console.WriteLine($"{input} Integer: {iValue}");
            }
        }

        /*  We notice the number start with A to Z. The base is 26 (A=1,Z=26).
            AA = A * 26 + A = 27
            ZZ = Z * 26 + Z = 27 * 26 = 702
            This is similar to the problem convert string to integer
            We can start from the left
            We have a sum = 0
            Iterate from i = 0 -> Length - 1
            Sum = Sum * 26 + current i letter value
            Return Sum

            AA
            i = 0 -> sum = 0 * 26 + A = 1
            i = 1 -> sum = 1 * 26 + A = 27

            Time Complexity is O(input.Lenght)
            Space Complexity is O(1)
        */      
        /*
            Best way to test is test when input is empty, input is A, input Z, input AA, input ZZ, input AAA (Boundary tests)
         */
        static int ConvertColumnStringToInt(string input)
        {
            // AB
            int sum = 0;
            for(int i = 0; i < input.Length; i++)
            {
                // sum  = 1 * 26 + 2 = 28
                sum = sum * 26 + ConvertLetterToInt(input[i]);
            }
            return sum;
        }

        /*
            Character can be used with math operators directly. The character would be convert into integer
            char.GetNumericValue('1') can only be used when you want to convert a number character into a number
         */
        static int ConvertLetterToInt(char letter)
        {
            return (int) letter - 'A' + 1;
        }

        /*
            1 -> A
            2 -> B
            27 => iteratively, perform modulo by 26 -> current char or remainder = 27 % 26 = 1 -> convert to char A
                then number / 26 = 1 -> convert to char A
                stop when number == 0
                we have AA
            No negative number assumption
            Create a StringBuilder to store all the letters
            Iteratively use a while loop
            The terminate condition is when the number == 0
            if it is not equal to modulo that number with 26 -> convert that integer into char and append into string builder
            divide the number by 26 -> and repeat the loop
            once finish the loop -> reverse the string builder since the result is appending to the end (backward)
            return the result;

            Edge case if the number is 0 -> return ""
            if the number is 1 perform as usual
            
            How to convert a number to character: (char)(Number + char A - 1)
         */
        static string ConvertIntToColumnString(int number)
        {
            StringBuilder sb = new StringBuilder();
            if(number <= 0)
            {
                return "";
            }
            while(number != 0)
            {
                int remainder = number % 26;

            }
        }

        static char ConvertIntToChar(int number)
        {
            return (char) ((char) number + 'A' - 1);
        }
    }
}
