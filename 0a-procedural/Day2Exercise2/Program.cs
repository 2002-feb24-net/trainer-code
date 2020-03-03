using System;

namespace Day2Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a staircase height: ");
            string input = Console.ReadLine();
            int length = int.Parse(input);
            for (int i = 0; i <= length; i++)
            {
                // debug print
                // Console.WriteLine(i);

                // solution 1
                // Console.WriteLine(new String(' ', length - i) + new String('#', i));

                // solution 2
                // for (int j = 0; j < length - i; j++)
                // {
                //     Console.Write(" ");
                // }
                // for (int j = 0; j < i; j++)
                // {
                //     Console.Write("#");
                // }
                // Console.WriteLine(); // line break

                // solution 3
                string stairs = new String('#', i);
                Console.WriteLine(stairs.PadLeft(length));
            }
        }
    }
}
