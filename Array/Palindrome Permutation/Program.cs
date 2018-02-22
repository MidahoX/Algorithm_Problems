using System;

namespace Palindrome_Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input:");
            string input = "Tact Coa";
            Console.WriteLine("Output: " + IsPalindromePermutation(input));
        }

        /*
            Assume the input only contains ASCII characters
            If the phrase is a palindrome, for each characters the count would be an even number except the case the input length is odd
            Remove the whitespaces since they are not considered according to the example
            Iterate through the input, count the number for each character and store in a map. Note: Lowercase each char
            Iterate through map and stop whenever there is an odd number if the input length is even
            If the input length is odd, stop when there is a second odd number
            Time complexity: O(N)
            Space complexity: O(1)
         */
        static bool IsPalindromePermutation(string input){
            int[] map = new int[256];
            int whiteSpaceCount = 0;
            for(int i = 0; i < input.Length; i++){
                if(input[i] != ' '){
                    int index = (int) char.ToLower(input[i]);
                    map[index]++;
                }
                else
                    whiteSpaceCount++;
            }

            int oddCounter = 0;
            int lengthWithoutSpace = input.Length - whiteSpaceCount;
            for(int i = 0; i < map.Length; i++){
                if(map[i] % 2 == 1){
                    if(lengthWithoutSpace % 2 == 0) {
                        return false;
                    }
                    else if(oddCounter == 0) {
                        oddCounter += 1;
                    }
                    else {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
