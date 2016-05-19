using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems
{
    public class StringProblem
    {
        public string SValue { get; set; }

        // Problem: Implement a methods that take a string representing an integer and return the corresponding interger
        //          and vice versa. You cannot use library function such as parseInt or Convert.ToInt32(). You should 
        //          handle negative integers.
        // Solution: We read each char in the string. And we check what number is it. Then we must compute the correct
        //           value based on the order. If the first letter is - than it is negative number.
        public int InterConvertStringToInterger(string input)
        {
            bool isNegative = false;
            int number = 0, negativeCount = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == '-')
                {
                    isNegative = true;
                    negativeCount = 1;
                }

                switch (input[i])
                {
                    case '0':
                        number = number +  0 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;
                    case '1':
                        number = number + 1 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;
                    case '2':
                        number = number + 2 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;
                    case '3':
                        number = number + 3 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;
                    case '4':
                        number = number + 4 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;
                    case '5':
                        number = number + 5 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;
                    case '6':
                        number = number + 6 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;
                    case '7':
                        number = number + 7 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;
                    case '8':
                        number = number + 8 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;
                    case '9':
                        number = number + 9 * (int) Math.Pow(10, input.Length - i - negativeCount);
                        break;                    
                }
            }

            return isNegative ? number * (-1) : number;
        }
    }
}
