using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesEventsLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print() calls the method, Print refers to the method

            ProcessString action2 = Console.Write;

            var list = new List<string> { "one", "two" };

            ForEach(list, Print, (string str) => { return str.ToUpper(); });
            ForEach(list, action2, str => str[0].ToString());

            // lambda expression is a shorthand syntax to write a "anonymous method"
            // this is for quick "disposable" functions

            // the best/most useful application of lambda expression / delegate types etc
            // is a part of the base class library called LINQ - stands for Language Integrated Query
            // - there's two ways to write it, one is weird and looks like SQL, called "query syntax"
            // - the other is called method syntax

            // calculate the average length of the strings in the list
            double average = list.Average(s => s.Length);

            // c# has a feature called "extension methods"
            // basically, you can write a static method in a static class, and tell C# to pretend that it's actually
            //   defined on the class of one of its first parameter.
            // it's "syntactic sugar" but does LOOK like you get to modify any class in C#
            // and add your own methods.

            char a = "abc".FirstCharacter();

            // LINQ is just a big pile of overloaded extension methods defined for the IEnumerable<T> interface

            // three types of LINQ methods
            // 1. the ones that return a new IEnumerable collection (they never modify the original collection)
            //    they don't execute "yet" - they use deferred execution.
            // 2. the ones that return any concrete value - like Average, First- do not use deferred execution
            // 3. things like ToArray, ToList. these return collections that need to be "all there"
            //     so they also don't use deferred execution.
            //    "ToList" lets you effectively force execution of type-1 methods whenever you want.

            // - Select: maps each element to something new
            // - Where: filters the collection according to some condition

            // - Distinct: filters out duplicates
            // - Skip: skips n elements
            // - Take: skips AFTER n elements

            // - Count: counts how many items (match a condition)
            // - First: returns the first item (matching a condition)

            Action<string> print = (s =>
            {
                Console.WriteLine(s);
            }); // you can use "block" syntax with lambda expressions as well as the "expression" syntax

            IEnumerable<string> noNulls = list.Where(x => x != null);
            var lastChar = noNulls.Select(x => x[x.Length - 1]);
            var upper = lastChar.Select(c => c.ToString().ToUpper());

            // no processing of the list has happened yet

            string first = upper.First(); // we get the first element of that new collection...
            // it processed the first item but hasn't looked at the others yet.

            List<string> list2 = upper.ToList(); // now it has processed all of the items.
            // because you have to be able to access any part of a List (not true of generic IEnumerable)
            //.... it has to process all the elements
        }

        // this looks like a method declaration maybe
        // but it declares a delegate type
        // this delegate is compatible with any function that takes in one string and returns nothing.
        delegate void ProcessString(string s);

        // since C# added generics, we've been able to specify delegates in a more flexible
        // but less self-descriptive way
        // that is the types Func<...> and Action<...>

        // for example:
        // Func<string, int> = any method with 1 string param, returning int.
        // Func<string, int, bool> = any method with 1 string param and 1 int param, returning bool.
        // Action<string, int> = any method with 1 string param, and 1 int param, returning nothing (void).

        //static void ForEach(List<string> list, ProcessString action)
        static void ForEach(List<string> list, ProcessString action, Func<string, string> transform)
        {
            foreach (string item in list)
            {
                string transformed = transform(item);
                action(transformed);
            }
        }

        static void Print(string s)
        {
            Console.WriteLine(s);
        }
    }
}
