using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Problems;

namespace ProblemUnitTests
{
    [TestClass]
    public class ArrayProblemUnitTest
    {
        public ArrayProblem InputArray { get; set; }

        [TestInitialize]
        [TestCleanup]
        public void CreateArray()
        {
            int[] array = new int[9] { 6, 5, 1, 3, 8, 4, 7, 9, 2 };
            InputArray = new ArrayProblem(array);
        }


        [TestMethod]
        public void Test_Array_Reorder_Even_Odd()
        {
            InputArray.ReorderEvenOdd();
            CollectionAssert.AreEqual(InputArray.Array, new int[] { 6, 2, 4, 8, 3, 1, 7, 9, 5 });
        }

        [TestMethod]
        public void Test_Array_Reorder_Even_Odd2()
        {
            InputArray.ReorderEvenOdd2();
            CollectionAssert.AreEqual(InputArray.Array, new int[] { 6, 2, 4, 8, 3, 1, 7, 9, 5 });
        }

        [TestMethod]
        public void Test_Array_Quicksort()
        {
            int[] array = new int[9] { 6, 5, 1, 3, 8, 4, 7, 9, 2 };
            InputArray.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(array, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            array = new int[9] { 3, 7, 8, 5, 2, 1, 9, 5, 4 };
            InputArray.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(array, new int[] { 1, 2, 3, 4, 5, 5, 7, 8, 9 });
        }

        [TestMethod]
        public void Test_Array_DutchFlagProblemSort()
        {
            ArrayProblem ap = new ArrayProblem(new int[] { 5, 6, 1, 3, 8 });
            ap.DutchNationalFlagSort(3);
            CollectionAssert.AreEqual(ap.Array, new int[] { 1, 3, 6, 5, 8 });


            ap = new ArrayProblem(new int[] { 2, 1, 1, 3, 3 });
            ap.DutchNationalFlagSort(4);
            CollectionAssert.AreEqual(ap.Array, new int[] { 1, 1, 2, 3, 3 });
        }
    }
}
