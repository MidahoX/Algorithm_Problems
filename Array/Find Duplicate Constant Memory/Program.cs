using System;

namespace Find_Duplicate_Constant_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PrintDuplicate(new int[] {1, 2, 3, 1, 3, 6 ,6});
        }

        // traverse the array,
        // at each index, get the original element value by modulo to N
        // add the index = element value by N 
        // once done, traverse the array again and check if the index value divide by N is more than 1, than
        // it is a duplicate
        static void PrintDuplicate(int[] input)
        {
            int n = input.Length;
            for(int i = 0; i < input.Length; i++) {
                int value = input[i] % n;
                input[value] += n; 
            } 

            for(int i = 0; i < input.Length; i++) {
                if(input[i] / n > 1) {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
