using System;

namespace TypesAndControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            // in c# for numbers, we mostly have int and double.
            int x = 4; // for integers, whole numbers. uses 4 bytes of space
            double d = 4.5; // for numbers that could have fractions. 8 bytes of space.

            // we can declare separately from assigning an initial value
            int x2; // default to 0
            // x = x2 + 2;
            x2 = 5;
            Console.WriteLine(x2);
            x2 = 6;
            Console.WriteLine(x2);

            bool exists = false;
            exists = true;
            exists = 5 * 5 < 26;
            // + - * /
            // % modulo
            //    used to check if a number is even or odd
            //   n % 2 == 0 (even), n % 2 == 1 (odd)

            // && and
            // || or
            // ! not

            // == (double equals)
            // != (not equals)
            // < <= > >=
            x = 5 % 2; // = 1.

            string str = "abc";
            str = str + str;
            Console.WriteLine(str);

            bool same = (str == "abcabc"); // in C# this is true.

            // decimal money = 4.12384768237462873;

            // Ctrl+/ toggles whether a line is commented.
            // if you type "cw<tab>" it expands to Console.WriteLine()

            // control flow
            string input = Console.ReadLine();
            int number = int.Parse(input); // converts a string to an int
            if (number == 3)
            {
                Console.WriteLine("it's three");
            }
            else
            {
                Console.WriteLine("it's not three");
            }

            // prints 0 1 2 3 4 on five lines
            for (int i = 0; i < 5; i++) // i++ means i = i + 1
            {
                Console.WriteLine(i);
            }
        }
    }
}
