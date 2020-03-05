using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int howMany = 40;
            for (int i = 0; i < howMany; i++)
            {
                Console.Write(FibonacciIterative(i) + " ");
            }
            Console.WriteLine("Method called " + counter + " times");
        }

        // get the "ith" fibonacci number
        // n: 0  1  1  2  3  5
        // i: 0  1  2  3  4  5
        static int FibonacciNumber(int i)
        {
            // base cases
            // if (i == 0) return 0;
            // if (i == 1) return 1;
            if (i < memoizedValues.Count) return memoizedValues[i];

            counter++;
            // recursive case
            // recursion is just a method calling itself
            int result = FibonacciNumber(i - 2) + FibonacciNumber(i - 1);
            memoizedValues.Add(result);
            return result;
        }

        static int counter = 0;

        // memoization is the technique
        // of remembering the return values of methods
        // that take a long time to execute
        static List<int> memoizedValues = new List<int>() { 0, 1 };

        static int FibonacciIterative(int i)
        {
            // version 2, no recursion allowed
            return 0;
        }
    }
}
