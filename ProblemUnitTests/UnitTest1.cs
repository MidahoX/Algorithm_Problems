using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Problems;

namespace ProblemUnitTests
{
    [TestClass]
    public class ArrayUnitTest
    {
        public ArrayProblems InputArray { get; set; }

        [TestInitialize]
        [TestCleanup]
        public void CreateArray()
        {
            int[] array = new int[9] { 6, 5, 1, 3, 8, 4, 7, 9, 2 };
            InputArray = new ArrayProblems(array);
        }


        [TestMethod]
        public void Test_Reorder_Even_Odd()
        {
            InputArray.ReorderEvenOdd();
            CollectionAssert.AreEqual(InputArray.Array, new int[] { 6, 2, 4, 8, 3, 1, 7, 9, 5 });
        }

        [TestMethod]
        public void Test_Reorder_Even_Odd2()
        {
            InputArray.ReorderEvenOdd2();
            CollectionAssert.AreEqual(InputArray.Array, new int[] { 6, 2, 4, 8, 3, 1, 7, 9, 5 });
        }

        [TestMethod]
        public void Test_Quicksort()
        {
            int[] array = new int[9] { 6, 5, 1, 3, 8, 4, 7, 9, 2 };
            InputArray.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(array, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            array = new int[9] { 3, 7, 8, 5, 2, 1, 9, 5, 4 };
            InputArray.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(array, new int[] { 1, 2, 3, 4, 5, 5, 7, 8, 9 });
        }
    }
}
