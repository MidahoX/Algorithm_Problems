using System;
using System.Diagnostics;

namespace ConsoleApplication
{
    public class Program
    {
        /*
        Ugly numbers are numbers whose only prime factors are 2, 3 or 5. 
        The sequence 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … shows the first 11 ugly numbers. By convention, 1 is included. 
        Given a number n, the task is to find n’th Ugly number.
         */
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stopwatch sp = new Stopwatch();
            sp.Start();
            Console.WriteLine(FindNthUglyNumber(150));
            sp.Stop();
            Console.WriteLine("Elapse time: {0}", sp.Elapsed);
            sp.Reset();
            sp.Start();
            Console.WriteLine(FindNthUglyNumberDP(150));
            sp.Stop();
            Console.WriteLine("Elapse time: {0}", sp.Elapsed);
        }

        public static bool IsUgly(long number){
            number = MaxDivisibleFactor(number, 2);
            number = MaxDivisibleFactor(number, 3);
            number = MaxDivisibleFactor(number, 5);

            return (number == 1) ? true : false;
        }

        public static long MaxDivisibleFactor(long number, int divider) {
            while(number % divider == 0){
                number = number/divider;
            }
            return number;
        }
        
        /*
        Naive approach. This would check all possible numbers until count is reach. Space complexity is O(1)
         */
        public static long FindNthUglyNumber(int n){
            long counter = 1;
            long number = 1;

            while(n > counter){
                number++;
                if(IsUgly(number)){
                    counter++;
                }
            }

            return number;
        }

        /*
        Dynamic Programming: An ugly number is a number that must be divided by 2, 3, 5. Use tabulation (bottom up) approach.
        We would have 3 columns for factors of 2, 3 and 5.
        2: 2 4  6
        3: 3 6  9
        5: 5 10 15
        To create the sequence, we would pick the ugly numbers in ascending order. We would need 3 pointers, each for 2, 3, 5.
        We would increase each of them and get the minimum. Then move to the next. Note at the case of 6, we would need to move both
        indexOf2 and indexOf3 (to avoid duplicates).
         */
        public static long FindNthUglyNumberDP(int n){
            long[] uglyNumbers = new long[n];
            long i = 0,
                 i2, i3, i5;
            i2 = i3 = i5 = 0;
            uglyNumbers[i] = 1;
            long nextFactorOf2 = 2,
                nextFactorOf3 = 3,
                nextFactorOf5 = 5;

            for(i = 1; i < n; i++) {
                uglyNumbers[i] =  Min(nextFactorOf2, nextFactorOf3, nextFactorOf5);

                if(uglyNumbers[i] == nextFactorOf2){
                    i2++;
                    nextFactorOf2 = uglyNumbers[i2] * 2;
                }
                if( uglyNumbers[i] == nextFactorOf3){
                    i3++;
                    nextFactorOf3 = uglyNumbers[i3] * 3;
                }
                if( uglyNumbers[i] == nextFactorOf5){
                    i5++;
                    nextFactorOf5 = uglyNumbers[i5] * 5;
                }
            }

            return uglyNumbers[n-1];
        }

        public static long Min(params long[] numbers){
           long min = numbers[0];
           for(int i = 1; i < numbers.Length; i++){
               if( min > numbers[i])
                min = numbers[i];
           }
           return min;
        }
    }
}
