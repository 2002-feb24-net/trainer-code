using System;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] array1 = { 3, 4, 2, 1, 6 }; // takes 5 swaps
            // int[] array1 = { 1, 2, 3, 4, 6 }; // takes 0 swaps
            int[] array1 = { 6, 4, 3, 2, 1 }; // takes 10 swaps
            Console.WriteLine("before sort: [" + string.Join(",", array1) + "]");

            BubbleSort(array1);
            Console.WriteLine("after sort: [" + string.Join(",", array1) + "]");
        }


        // 1. look at each consecutive pair,
        //    swap them if they are not in order

        // e.g. this method will turn { 3 2 1 } into ... { 2 1 3 }
        // returns true if the array was modified (i.e. it wasn't
        // sort when we started the pass)
        static bool BubbleSortOnePass(int[] array)
        {
            bool changed = false;
            // iterate pair by pair
            // first pair: (0 and 1)
            // last pair: (len-2 and len-1).
            // therefore i should start at 0 and stop before len-1
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    changed = true;
                    // swap using a temporary variable
                    int swap = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = swap;
                }
            }
            return changed;
        }

        // 2. do it again, until you go a whole
        //    pass without making any swaps
        static void BubbleSort(int[] array)
        {
            bool changed = BubbleSortOnePass(array);
            while (changed)
            {
                changed = BubbleSortOnePass(array);
            }
        }
    }
}
