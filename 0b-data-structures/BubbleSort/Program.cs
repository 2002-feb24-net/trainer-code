using System;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 3, 4, 2, 1, 6 };
            Console.WriteLine("before sort: [" + string.Join(",", array1) + "]");

            BubbleSort(array1);
            Console.WriteLine("after sort: [" + string.Join(",", array1) + "]");
        }

        static void BubbleSort(int[] array)
        {
            // 1. look at each consecutive pair,
            //    swap them if they are not in order

            // 2. do it again, until you go a whole
            //    pass without making any swaps
        }
    }
}
