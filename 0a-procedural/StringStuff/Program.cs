using System;

namespace StringStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write is like WriteLine, but without the line break at the end
            Console.Write("Enter some text: ");
            string input = Console.ReadLine();

            if (input.Contains("Nick")) // case-sensitive by default
            {
                // Console.WriteLine(input);
                Console.WriteLine("input contained 'Nick'");
            }

            // input.EndsWith
            // input.StartsWith
            // input.Equals("abc") // but in C#, just use input == "abc"
            // input.IndexOf // like Contains, but instead of returning
            //      true, it returns where in the string it found the result.
            //      instead of false, it returns -1.

            // how we count indexes in a string: starting from 0
            // 0123456789
            // http://www.google.com

            Console.Write("index of '.': ");
            int index = input.IndexOf(".");
            Console.WriteLine(index);

            Console.Write("After the first dot: ");
            Console.WriteLine(input.Substring(index + 1));

            int length = input.Length; // how many characters
            int numWords = input.Split(' ').Length; // how many space-separated parts
            //      (uses a temporary array)

            string withoutSpaces = input.Replace(" ", "--");
            Console.WriteLine(withoutSpaces);

            Console.WriteLine("lowercase: " + input.ToLower());
            Console.WriteLine("uppercase: " + input.ToUpper());

            // exercise: reverse a string

            // array
            string[] words = input.Split(' ');
        }
    }
}
