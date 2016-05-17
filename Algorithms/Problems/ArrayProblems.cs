using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems
{
    public class ArrayProblems
    {
        public int[] Array {
            get; set;
        }

        public ArrayProblems(int[] array)
        {
            // make a copy of parameter array
            Array = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                Array[i] = array[i];
            }
        }

        // swap number values
        public void Swap(int[] a, int x, int y)
        {
            if (x != y)
            {
                int temp = a[x];
                a[x] = a[y];
                a[y] = temp;
            }
        }

        // Problem:     Given an array. Reorder so that even entries appear first.
        // My Solution: Bruteforce. Start from one end, if encounter odd entry, do another foor loop from the back
        //              and find an even entry to swap. Stop when j <= i.
        //              O(N): complexity.
        public void ReorderEvenOdd()
        {            
            for(int i = 0; i < Array.Length; i++)
            {
                if(Array[i] % 2 == 1)
                {
                    // find a even entry from the back and swap
                   
                    for(int j = Array.Length - 1; j > i; j--)
                    {
                        if(Array[j] % 2 == 0)
                        {
                            Swap(Array, i, j);
                            break;
                        }
                    }
                }
            }
        }

        // Improvement: Instead of starting from the last index, remember j location and start from there for the next i index
        public void ReorderEvenOdd2()
        {
            int j = Array.Length - 1;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] % 2 == 1)
                {
                    while (j > i)
                    {
                        if (Array[j] % 2 == 0)
                        {
                            Swap(Array, i, j);                            
                            break;
                        }
                        j -= 1;
                    }
                }
            }
        }        

        // Problem:     Quicksort (Lomuto): Pick the pivot, paritition the array into 3 sub arrays. all entries smaller than pivot will be at the front and bigger
        //              entries will be in the back. Continue quicksort on each sub arrays recursively until the entire array is sorted       
        public void QuickSort(int[] a, int low, int high)
        {            
            if (low < high)
            {
                int pivot = Partition(a, low, high);
                QuickSort(a, low, pivot - 1);
                QuickSort(a, pivot + 1, high);
            }
        }

        public int Partition(int[] a, int low, int high)
        {
            int pivot = a[high],
                i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (a[j] <= pivot)
                {
                    i += 1;
                    Swap(a, i, j);
                }
            }
            i += 1;
            Swap(a, i, high);

            return i;
        }

        // Problem: Dutch National Flag Problem
        //          Write a program that takes an array A and an index i into A, and rearranges the elemtns such that all elements less than A[i] appear first
        //          followed by equal to pivot, followed by elements greater than pivot.
        


    }
}
