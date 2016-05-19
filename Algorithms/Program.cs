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
            ArrayProblem ap = new ArrayProblem(new int[] { 2, 1, 1, 3, 3, 2, 1 });
            ap.DutchNationalFlagSort(3);
            PrintResults(ap.Array);
        }
        
        public static void PrintResults(int [] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
            
    }
}
