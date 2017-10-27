using System;

namespace ConsoleApplication
{
    /*
        The cost of stock on each day is given in an array, find the max profit that you can make by buying and selling in those days. For example, if the given array is 
        {100, 180, 260, 310, 40, 535, 695}, the maximum profit can earned by buying on day 0, selling on day 3. Again buy on day 4 and sell on day 6. If the given array
        is sorted in decreasing order, then profit cannot be earned at all
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        // The max profit is obtained by summing the profit between buying lowest and selling at highest. 
        // If there is no pair of minima and maxima -> no profit
        public static void MaxProfitStockBuySell(int[] price, int n)
        {
            
        }
    }
}
