using System;

namespace Rotate_Matrix
{
    /*
        Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, 
        Write a method to rotate the image 90 degree. Can you do it in place?
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[,] input = new int[,] {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };
            PrintMatrix(input);
            PrintMatrix(RotateSquareMatrix(input));

            input = new int[,] {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            PrintMatrix(input);
            PrintMatrix(RotateSquareMatrix(input));

            input = new int[,] {
                {1, 2},
                {3, 4}
            };
            PrintMatrix(input);
            PrintMatrix(RotateSquareMatrix(input));
        }

        static void PrintMatrix(int[,] input)
        {
            for (int row = 0; row < input.GetLength(0); row++)
            {
                for (int col = 0; col < input.GetLength(1); col++)
                {
                    Console.Write(input[row, col] + "\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        static int[,] RotateSquareMatrix(int[,] input)
        {
            int dimension = input.GetLength(0);
            int[,] newMatrix = new int[dimension, dimension];
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    int updatedRow = col;
                    int updatedCol = dimension - 1 - row;

                    newMatrix[updatedRow, updatedCol] = input[row, col];
                }
            }

            return newMatrix;
        }
    }
}
