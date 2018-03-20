using System;

namespace C_
{
    class Program
    {
        // Problem: Find the only non duplicated in sorted array.
        //          Duplicates element always come in pair
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[] { 1, 1, 2, 2, 3, 4, 4 };
            jaggedArray[1] = new int[] { 0, 1, 1, 2, 2, 4, 4 };
            jaggedArray[2] = new int[] { 1, 1, 2, 2, 3, 4, 4, 5, 5 };
            jaggedArray[3] = new int[] { 0, 1, 1, 2, 2, 4, 4, 5, 5 };
            for(int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                Console.WriteLine(FindNonDuplicateInSortedArray(jaggedArray[i], 0, jaggedArray[i].Length-1));
            }
        }

        // Observation: 
        //      Before the non duplicate, first dup starts at even index, second dup starts at odd index
        //      After the non duplicate, first dup starts at odd index, second dup starts at even index
        //      The non duplicate is always at even index (since before it second dup is always at odd index)
        //  Solution:
        //      Keep spliting the array, and determine where the non dup belong
        //      1) Base case: start > end -> return -1
        //                    start == end -> return index. Ex 1 2 2
        //      2) Calculate midpoint = (start + end) / 2
        //         If midpoint == even
        //              if midpoint == mid + 1 -> Ex: 1 2 2 3 3 -> be in the right -> [mid+2, end] (before target -> even index = even + 1)
        //              else -> 1 1 2 3 3 -> be in the right, [start, mid] 
        //         If midpoint == odd:
        //              if midpoint == midpoint + 1 -> Ex: 3 4 4 -> be in the left -> [start,mid - 1]
        //              else -> Ex 4 4 5 5 7 7 8 -> right -> [midpoint+1, end]
        // Each time we have less than half of the array -> O(logN)
        static int FindNonDuplicateInSortedArray(int[] array, int start, int end)
        {
            if (start > end)
                return -1;
            else if(start == end)
                return array[start];
            else
            {
                int mid = (start + end) / 2;
                if (mid % 2 == 0)
                {
                    // If mid is even and the next element is the same -> on the left
                    // Ex: a b c(!) d e
                    if(array[mid] == array[mid+1])
                        return FindNonDuplicateInSortedArray(array, mid+2, end);
                    else
                        return FindNonDuplicateInSortedArray(array, start, mid); // not mid - 2 since c may be difference than b and d.
                }
                else
                {
                    // If mid is odd,
                    // Ex: a b c d(!) e f g
                    if(array[mid] == array[mid+1])
                        return FindNonDuplicateInSortedArray(array, start, mid-1);
                    else
                        return FindNonDuplicateInSortedArray(array, mid+1, end);
                }
            }
        }
    }
}
