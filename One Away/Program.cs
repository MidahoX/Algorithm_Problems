using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string s1 = "pale", s2 = "bake";
           
            Console.WriteLine("s1: " + s1);
            Console.WriteLine("s2: " + s2);
            Console.WriteLine("Is One Edit Away: " + IsOneAway(s1, s2).ToString());
        }

        public static bool IsOneAway(string s1, string s2){
            if (s1.Length == 0 && s2.Length == 0)
                return false;
            if(Math.Abs(s1.Length - s2.Length) > 1)
                return false;
            if(s1.Length > s2.Length)
                return CountNumOfEdits(s2, s1);
            else
                return CountNumOfEdits(s1, s2);
        }

        // pale and bake
        public static bool CountNumOfEdits(string shorterString, string longerString){
            int numOfEdits = 0, // 0
                sIndex = 0,     // 0
                lIndex = 0;     // 0

            // 
            while(sIndex < shorterString.Length 
                && lIndex < longerString.Length) {
                if(shorterString[sIndex] == longerString[lIndex]) {
                    sIndex++;
                    lIndex++;
                } else {
                    numOfEdits++;
                    lIndex++;
                }

                if(lIndex > longerString.Length - 1 && sIndex < shorterString.Length) {
                    // reset the number of edits to shorter string
                    // pale, bale
                    sIndex++;
                    lIndex = sIndex;
                    numOfEdits = sIndex;
                }
            }

            if(numOfEdits > 1)
                return false;
            return true;
        }
    }
}
