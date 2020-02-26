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
            // Console.ReadLine();
            // if (input == "removenegatives")
            // {
            //     removeNegatives(array)
            // }
            // PrintArray(array);
        }

        // given any integer array,
        // print out all its values
        static void PrintArray(int[] a)
        {
            Console.Write("Array contents: ");

            for (int i = 0; i < a.Length; i++)
            {
                string numAsString = a[i].ToString();
                Console.Write(numAsString + " ");
            }
            Console.WriteLine();
        }

        static int[] InterpretStringAsArray3(string str)
        {
            string[] newArray = str.Split(" ");
            int al = newArray.Length;
            int[] numbArray = new int[al];
            for (int i = 0; i < newArray.Length; i++)
            {
                numbArray[i] = int.Parse(newArray[i]);
            }
            //int[] numArray = Array.ConvertAll(newArray, int.Parse);
            System.Console.WriteLine(numbArray);
            return numbArray;
        }

        static int[] InterpretStringAsArray(string str)
        {
            // split array on space characters.
            string[] parts = str.Split(' ');
            // make a new int array with the right size.
            int[] nums = new int[parts.Length];
            // loop, for each string, convert it to an int.
            for (int i = 0; i < parts.Length; i++)
            {
                // before this line, nums[i] is at its default of 0.
                nums[i] = int.Parse(parts[i]);
                // now, it has the numerical value of parts[i].
            }
            // send the new array back to the code that is using InterpretStringAsArray.
            return nums;
        }

        static int[] InterpretStringAsArray2(string str)
        {
            return Array.ConvertAll(str.Split(' '), int.Parse);
        }

        static string GetInput()
        {
            Console.WriteLine("Enter a list of whole numbers separated by spaces.");
            Console.WriteLine("e.g.: '12 3 -2 0'");
            string input = Console.ReadLine();
            return input;
        }

        // any method is going to have
        // 1. a name
        // 2. a return value: either nothing (void), or some type e.g. int
        // what result does the method need to send back to the code that uses this method.
        // 3. a list of parameters (maybe empty)
        // does the method need any input from the code that uses it to do its job.
        static int Add(int a, int b)
        {
            int result = a + b;
            return result;
            // you use "return" to send the return value back to the
            // code that calls this method.
        }
    }
}
