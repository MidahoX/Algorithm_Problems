using System;
using System.Text;

namespace String_Compression
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "aabccccc";
            Console.WriteLine("The compressed string of {0} is {1}", input, Compress(input));
            Console.WriteLine("The compressed string v2 of {0} is {1}", input, Compress(input));
            
            string input1 = "aa";
            Console.WriteLine("The compressed string of {0} is {1}", input1, Compress(input1));
            Console.WriteLine("The compressed string v2 of {0} is {1}", input1, Compress(input1));
            
            string input2 = "abc";
            Console.WriteLine("The compressed string of {0} is {1}", input2, Compress(input2));
            Console.WriteLine("The compressed string v2 of {0} is {1}", input2, Compress(input2));
            
            //Console.Write(input[0]);
            
            //Console.Write(input[0].ToString());
        }

        /*
        Implement a method to perform basic string compression using the counts of repeated characters.
        For example: the string aabccccc would become a2b1c5a3. 
        If the compressed string would not become smaller than the original string,
        your method should return the original string. You can assume the string has only uppercase and lowercase letters (a-z)
         */

        /*
            Algorithm:
                Use a counter to count the duplication.
                Iterate through each character in the input.
                If the next value is out of bound or different than the current value -> write the current character, and the counter
                    Be sure to reset the counter back to 1
                If the next value is the same as the current, increase the counter
                Increase the iterator after the loop.
            Time complexity: O(N)
         */
        static string Compress(string input)
        {
            if (input.Length < 2)
                return input;
            int countConsecutive = 0;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < input.Length; i++) {
                countConsecutive++;
                if(i + 1 == input.Length || input[i] != input[i + 1]){
                    sb.Append(input[i]);
                    sb.Append(countConsecutive.ToString());
                    countConsecutive = 0;
                }
            }
            return sb.Length > input.Length ? input : sb.ToString();
        }

        /*
            This version is more optimally by doing two loop. One count the duplicate to set up the result length, save space.
            StringBuilder duouble its capacity whenever the max length is reached.
         */
        static string Compress2(string input)
        {
            if (input.Length < 2)
                return input;
            int countConsecutive = 0;
            int resultLength = CountResultLength(input);
            StringBuilder sb = new StringBuilder(resultLength);

            for(int i = 0; i < input.Length; i++) {    
                countConsecutive++;
                if(i + 1 == input.Length || input[i] != input[i + 1]){
                    sb.Append(input[i]);
                    sb.Append(countConsecutive.ToString());
                    countConsecutive = 0;
                }
            }

            return resultLength > input.Length ? input : sb.ToString();
        }

        static int CountResultLength(string input){
            int length = 0;
            int countConsecutive = 0;
            for(int i = 0; i < input.Length; i++){
                countConsecutive++;
                if(i + 1 == input.Length || input[i] != input[i+1]) {
                    length += 1 + countConsecutive.ToString().Length;
                } 
            }

            return length;
        }
    }
}
