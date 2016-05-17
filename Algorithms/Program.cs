using Algorithms.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5] { 2, 3, 1, 5, 4 };

            ArrayProblems t = new ArrayProblems(array);

            t.QuickSort(array, 0, array.Length - 1);

            PrintResults(array); 
        }
        
        public static void PrintResults(int [] array)
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
            
    }
}
