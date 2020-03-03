using System;

namespace ReverseStringWithoutMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input a string: ");
            string input = Console.ReadLine();

            string data = input;

            int length = data.Length;
            string reversedString = "";

            for (int i = length - 1; i >= 0; i--)
            {
                reversedString += data[i];
            }
            Console.WriteLine("Reversed String: " + reversedString);
        }
    }
}
