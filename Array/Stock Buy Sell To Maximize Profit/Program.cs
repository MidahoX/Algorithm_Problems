using System;
using System.Collections.Generic;

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
            int[] price = { 100, 180, 260, 310, 40, 535, 695 };
            PrintArray(price);
            Console.WriteLine(MaxProfitStockBuySell(price, price.Length));
            Console.WriteLine();

            int[] price1 = { 1, 2, 100 };
            PrintArray(price1);
            Console.WriteLine(MaxProfitStockBuySell(price1, price1.Length));
            Console.WriteLine();

            int[] price2 = { 1, 2, 3, 4 };
            PrintArray(price2);
            Console.WriteLine(MaxProfitStockBuySell(price2, price2.Length));
            Console.WriteLine();
            
            int[] price3 = { 2, 2 };
            PrintArray(price3);
            Console.WriteLine(MaxProfitStockBuySell(price3, price3.Length));
            Console.WriteLine();

            int[] price4 = { 3, 2 , 1 , 0 };
            PrintArray(price4);
            Console.WriteLine(MaxProfitStockBuySell(price4, price4.Length));
            Console.WriteLine();

            int[] price5 = { 3 };
            PrintArray(price5);
            Console.WriteLine(MaxProfitStockBuySell(price5, price5.Length));
            Console.WriteLine();
        }

        public static void PrintArray(int[] price)
        {
            Console.WriteLine(string.Join(" ", price));
        }

        // Assumption: You can only buy and sell one at a time.
        // The max profit is obtained by summing the profit between buying local min  and selling at local max. 
        // If there is no pair of minima and maxima -> no profit
        // iterate through the array, get find the local minima, then find the maxima -> put them into a list
        //      finding minima: start with the current index, if the value is larger or equal than the next, move to the next (Limit is n - 2 becacuse we comparing to the next element
        //          if it is n - 1, last element then stop
        //      finding maxima: start with the current index, if the vavlue is smaller or equal than the next, move to the next. If it is the end, stop
        //          if found maxim -> add the pair to the list. The limit is n -1 since we are comparing to the previous
        // Once we have the list if there is no pair then profit is zero
        // Otherwise, sum the difference
        public static int MaxProfitStockBuySell(int[] price, int  n)
        {
            if (n < 2)
                return 0;
            List<Transaction> transactions = new List<Transaction>();
            int i = 0;
            while (i < n)
            {
                while (i < n - 1 && price[i] >= price[i + 1])
                    i++;
                if( i == n -1)
                    break;
                int localMinIndex = i++;

                while (i < n && price[i] >=  price[i - 1])
                    i++;
                int localMaxIndex = i - 1;
                transactions.Add(new Transaction() { Buy = localMinIndex, Sell = localMaxIndex });
            }

            if(transactions.Count == 0)
                return 0;
            else {
                int sum = 0;
                foreach(var t in transactions){
                    Console.WriteLine(string.Format("Buy on day {0} at {1}. Sell on day {2} at {3}", 
                        t.Buy,
                        price[t.Buy],
                        t.Sell,
                        price[t.Sell]));
                    sum += price[t.Sell] - price[t.Buy];
                    Console.WriteLine("Current profit " + sum);
                }
                return sum;
            }
        }
    }

    public class Transaction
    {
        public int Buy;
        public int Sell;
    }
}
