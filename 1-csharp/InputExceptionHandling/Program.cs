using System;

namespace InputExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        const int MaxTries = 5;

        static int GetInputWithCheckingBeforehand()
        {
            int number;
            bool gotNumber = false;
            int numberOfTries = 0;
            while (!gotNumber)
            {
                if (numberOfTries > MaxTries)
                {
                    throw new Exception("Stop breaking things");
                }

                Console.Write("Enter a number: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    return number;
                }
                numberOfTries++;
            }
        }

        static int GetInputWithExceptions()
        {
            int number;
            bool gotNumber = false;
            while (!gotNumber)
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();
                try
                {
                    number = int.Parse(input);
                    gotNumber = true;
                }
                catch (FormatException)
                {
                }
            }
            return number;
        }
    }
}
