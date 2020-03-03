using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // arrays are the most fundamental/basic way to
            // have a collection/sequence of data in C#.

            // the main rules about them:
            // 1) once they've been created, they can't get larger or smaller
            // 2) you can only hold one type of thing in a given array

            // ways to make an array:
            // 1) get it from some built-in method, e.g.
            string[] words = "a sentence".Split(' ');
            // 2) make it with default values
            int[] numbers = new int[8]; // length 8, all starting at zero.
            // 3) array initializer
            int[] moreNumbers = { 1, 6, 4, 9, int.Parse("12") }; // length 5, with given initial values

            // we can access any value by index
            int firstValue = moreNumbers[0];
            // just like strings, arrays indexes start at 0 and go up to Length - 1.
            moreNumbers[1] = 5; // set the second value to 5.

            int length = moreNumbers.Length;
            int[] newCopy = new int[moreNumbers.Length];
            Array.Copy(moreNumbers, newCopy, length);

            int index = Array.IndexOf(moreNumbers, 3); // index of first 3 found in array.
        }
    }
}
