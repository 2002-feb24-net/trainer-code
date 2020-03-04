using System;
using System.Collections.Generic;

namespace Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            // hashsets
            // HashSet<string> bagOfStrings = new HashSet<string> { "abc", "bca" };

            HashSet<string> bagOfStrings = new HashSet<string>();

            bagOfStrings.Add("Russell");
            bagOfStrings.Add("Mahir");
            bagOfStrings.Add("Paul");
            bagOfStrings.Add("Paul"); // this effectively does nothing at all

            Console.WriteLine(bagOfStrings.Count); // 3

            bool isPaulHere = bagOfStrings.Contains("Paul"); // true
            bagOfStrings.Remove("Paul");

            // basically the same as AddRange on List
            bagOfStrings.UnionWith(new string[] { "abc", "bca", "b", "b", "b" });

            foreach (string value in bagOfStrings)
            {
                if (value == "the one we're looking for")
                {
                    //run code
                }
            }

            List<string> listOfStrings = new List<string>();
            listOfStrings.AddRange(bagOfStrings);
            // those two have the same Count now

            listOfStrings.Add(listOfStrings[0]); // add a duplicate
            HashSet<string> secondBag = new HashSet<string>();
            secondBag.UnionWith(listOfStrings);
            // now the list has one more Count than this set does
        }

        // copy from my codesignal demo:
        int firstDuplicate(int[] a)
        {
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < a.Length; i++)
            {
                // if this is the second time we've seen this
                // value, then the current one is a duplicate
                if (seen.Contains(a[i]))
                {
                    return a[i];
                }
                // put this element in the list
                seen.Add(a[i]);
                // but if it was already in there,
                //    return the current index
            }
            // if i made it this far without returning
            // it must be that there are no dupes.
            return -1;
        }

    }
}
