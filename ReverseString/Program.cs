using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input a string: ");
            string input = Console.ReadLine();
            Reverse(input);
        }

        static void Reverse(string input)
        {
            int length = input.Length;
            string reversedString = "";
            for (int i = length - 1; i >= 0; i--)
            {
                reversedString += input[i];
            }
            Console.WriteLine("Reversed String: " + reversedString);
        }

        static void Reverse2(string input)
        {
            string exString = "abc.123.def.456";
            char[] exCharArray = exString.ToCharArray();
            Array.Reverse(exCharArray);
            string revExString = String.Concat(exCharArray);
            Console.WriteLine(revExString);
        }
    }
}
