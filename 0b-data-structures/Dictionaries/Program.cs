using System;
using System.Collections.Generic;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameToGradeMap = new Dictionary<string, int>();

            // indexing
            nameToGradeMap["Bob"] = 91;

            string[] names = { "A", "B", "C" };
            int[] grades = { 1, 2, 3 };
            nameToGradeMap = new Dictionary<string, int>()
            {
                ["Bill"] = 59
            };

            foreach (var item in nameToGradeMap)
            {
                string key = item.Key;
                int value = item.Value;
            }
        }

        // instead of using a Dictionary,
        // we could use a class to combine those
        // two values, and store a List of class instances.
        class Student
        {
            string name;
            int grade;
        }
    }
}
