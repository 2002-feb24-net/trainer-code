using System;

namespace ArrayEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 1, 2, 3, 4 };
            int[] array3 = { 1, 2, 3, 4 };
            int[] array4 = { 0, 2, 3 };

            if (ArraysEqual(array1, array2))
            {
                Console.WriteLine("1 & 2 equal"); // shouldn't print
            }
            if (ArraysEqual(array2, array3))
            {
                Console.WriteLine("2 & 3 equal");  // should print
            }
            if (ArraysEqual(array3, array4))
            {
                Console.WriteLine("3 & 4 equal");  // shouldn't print
            }
        }

        static bool ArraysEqual(int[] arrayA, int[] arrayB)
        {
bool equal = true;

            // 1. it could only be equal if the lengths are equal
            if (arrayA.Length == arrayB.Length)
            {
                for (int i = 0; i < arrayA.Length; i++)
                {
                    // for each index...
                    if (arrayA[i] != arrayB[i])
                    {
                        equal = false;
                    }
                }
            }
            else
            {
                equal = false;
            }

            if (equal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
