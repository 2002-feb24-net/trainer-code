using System;

namespace Day2Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            // separation of input processing
            // and the actual logic of the program
            // "separation of concerns"
            Console.WriteLine("Please input a number:");
            int input = int.Parse(Console.ReadLine());
            // some code examples use Convert.ToInt32
                // instead of int.Parse; that's fine

            // solution 1 (recursion, advanced)
            // RunProgram(input);

            // solution 2: while loop
            while (input != 1)
            {
                if (input % 2 != 0)
                {
                    input = input * 3 + 1;
                }
                else
                {
                    input /= 2;
                }
                Console.WriteLine(input);
            }
        }

        static int RunProgram(int x)
        {
            // this method broadly does either:
            //     if we've reached the end of our computation,
            //           (at 1), then stop and return 1.
            //     otherwise, return the next Collatz number.
            if (x == 1)
            {
                return (x);
            }
            else if (x % 2 == 0)
            {
                x = x / 2;
            }
            else if (x % 2 == 1)
            {
                x = (x * 3) + 1;
            }
            Console.WriteLine(x);
            return RunProgram(x);
        }
    }
}
