using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 1, 5, 7, 3, 9, 6, 7 };
            // left 1,5,7
            // right 3,9,6,7

            Console.WriteLine("before sort: [" + string.Join(",", data) + "]");

            MergeSort(data);
            Console.WriteLine("after sort: [" + string.Join(",", data) + "]");
        }

        // 1. if the array is size 1, it's already sorted. otherwise, it's bigger,
        //       and we'll split it up to get two simpler sub-problems.
        // 2. split the array into two subarrays down the middle.
        // 3. sort each subarray using this method that knows how to sort arrays,
        //       the one we're writing now.
        // 4. combine your two sorted subarrays, one by one through both of them,
        //      keeping the result sorted overall.
        static void MergeSort(int[] array)
        {
            // base case
            // if size is 0 or 1... stop here, it's already sorted.
            if (array.Length < 2)
            {
                return;
            }

            // recursive case
            int middle = array.Length / 2; // for example, if length 5, middle will be 2.

            int[] left = SubArray(array, 0, middle);
            int[] right = SubArray(array, middle, array.Length);

            MergeSort(left);
            MergeSort(right);

            // combine them.
            int l = 0;
            int r = 0;
            for (int i = 0; i < array.Length; i++)
            {
                // what if we've already finished either left or right? ...
                if (l >= left.Length)
                {
                    array[i] = right[r];
                    r++;
                }
                else if (r >= right.Length)
                {
                    array[i] = left[l];
                    l++;
                }
                // but if we haven't, then, we need to compare left and right.
                else if (left[l] <= right[r])
                {
                    array[i] = left[l];
                    l++;
                }
                else
                {
                    array[i] = right[r];
                    r++;
                }
            }
        }

        //          |-----|
        //        0  1  2  3
        // array [5, 8, 4, 8]
        // start 1, end 3
        // result should be [8, 4]
        static int[] SubArray(int[] array, int start, int end)
        {
            int length = end - start;
            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = array[start + i];
            }

            return result;
        }
    }
}
