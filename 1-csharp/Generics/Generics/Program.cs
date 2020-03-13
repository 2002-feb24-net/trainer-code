using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayLists();

            // whenever we use a type with <> at the end
            // that is a generic type
            // and the specific thing you put in the <> is called the type parameter.
            var list = new List<int>();
            var list2 = new List<string>();

            var sortedlist = new SortedSequence<string>();
            sortedlist.Add("asdf");
            sortedlist.Add("as");
            sortedlist.Add("a");
            for (int i = 0; i < 3; i++)
            {
                string s = sortedlist[i];
                Console.Write(s + " ");
            }
        }

        private static void ArrayLists()
        {
            var arraylist = new ArrayList();

            arraylist.Add(1);
            arraylist.Add(2);
            arraylist.Add(3);
            arraylist.Add(new ArrayList());
            arraylist.Add("asdf");

            // when used with the non-generic IEnumerable interface
            // it will attempt to cast to whatever type you put here
            //        v
            foreach (int num in arraylist)
            {
                //int num2 = (int)num;
                Console.Write($"{num + 1} ");
            }
        }
    }
}
