using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[,] matrix = {
                {1, 2, 3, 4}, 
                {5, 6, 7, 8},
                {9, 10 ,11 ,12},
                {13, 14,15,16}
                };

            
        }

        /*
            Matrix Rotate: Rotate a square matrix anti clockwise 90 deg in place (without using any extra data structure)
         */
         public static void RotateMatrix(int [,] input){
             int dimension = input.GetLength(0);
             int rotateCycles = dimension / 2;


            // matrix : 4 x 4 -> rotateCycles = 2;
            // cycle 1 -> row = 0;
            // 
            // cycle 2 -> row = 1;
             for(int row = 0; row < rotateCycles; row++) {
                 for(int col = row; col < dimension - 2; col++){    // col = 1;
                     int temp = input[row,col]; // input[0,1] = 2 = temp
                     input[row,col] = input[row, dimension - 1 - col]; // 0,1 = 0,3-1 = 0, 2 = 4
                     input[row,dimension - 1 - col] = input[dimension - 1 - row, dimension - 1 - col];  // 0, 3 = 3,3 = 16
                     input[dimension - 1 - row, dimension - 1 - col] = input[dimension - 1 - row, col]; // 3,3 = 3,0 = 13
                     input[dimension - 1 - row, col] = temp; // 3,0 = 1
                 }
             }
         }
    }
}
