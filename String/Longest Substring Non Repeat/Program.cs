using System;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        /*
        Given a string, find the length of the longest substring without repeating characters.
        Examples:
        Given "abcabcbb", the answer is "abc", which the length is 3.
        Given "bbbbb", the answer is "b", with the length of 1.
        Given "pwwkew", the answer is "wke", with the length of 3. 
        Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
         */
        public static void Main(string[] args){
            string input = "abcabcbb";
            Console.WriteLine("Longest substring with non repeat characters: {0}", LongestSubstringNonRepat(input));
        }

        public static string LongestSubstringNonRepat(string input)
        {
            // need a map to track the number of character appears so far
            // iterate through the array if there is a reappearance -> reset hashmap, update the longest substring if appropriate

            // assume the input is an array of ASCII -> 256 characters
            StringBuilder sb = new StringBuilder();
            bool[] map = new bool[256];
            for(int i = 0; i < input.Length; i++) {
                int asciiVal = (int)Char.GetNumericValue(input[i]);
                if(!map[asciiVal]) {
                    map[asciiVal] = true;
                    sb.Append(input[i]);
                }
                else{
                    
                }
            }
        }
    }
}
