using System;

namespace ArrayModifier
{
    class Program
    {
        // accept input from user, list of numbers separated by spaces
        // interpret that as an int array
        // print the array's values back to the user
        // ask the user for some operation
        // print the array's new values to the user.
        static void Main(string[] args)
        {
            string input = GetInput();
            int[] array = InterpretStringAsArray(input);
            PrintArray(array);
        }

        static void PrintArray(int[] a)
        {

        }

        static int[] InterpretStringAsArray(string str)
        {

        }

        // any method is going to have
        // 1. a name
        // 2. a return value: either nothing (void), or some type e.g. int
            // what result does the method need to send back to the code that uses this method.
        // 3. a list of parameters (maybe empty)
            // does the method need any input from the code that uses it to do its job.
        static string GetInput()
        {

        }

        static int Add(int a, int b)
        {
            int result = a + b;
            return result;
            // you use "return" to send the return value back to the
            // code that calls this method.
        }
    }
}
