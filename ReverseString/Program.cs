using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            // a variable always has exactly one declaration(where you give it its type)
            // and that variable is "in scope" (accessible) from that line until the next "}"

            Console.Write("Input a string: ");
            string input = Console.ReadLine();
            Reverse(input);
        }

        static void Reverse(string data)
        {
            // "input" in here, is an error
            // because that variable is not in scope.
            // C# keeps things organized this way.
            int length = data.Length;
            string reversedString = "";

            for (int i = length - 1; i >= 0; i--)
            {
                reversedString += data[i];
            }
            Console.WriteLine("Reversed String: " + reversedString);
        }

        // static void Reverse2(string input)
        // {
        //     string exString = "abc.123.def.456";
        //     char[] exCharArray = exString.ToCharArray();
        //     Array.Reverse(exCharArray);
        //     string revExString = String.Concat(exCharArray);
        //     Console.WriteLine(revExString);
        // }
    }
}
