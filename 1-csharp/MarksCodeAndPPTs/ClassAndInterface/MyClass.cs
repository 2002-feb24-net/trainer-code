using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndInterface
{
    class MyClass : Interface1
    {
        public int myInt1 = 11;
        public String myString1 { get; }

        private int myInt2 = 10;
        private String myString2 = "I am a private string";

        public static String myString3;

        public MyClass(){}

        public MyClass(int myInt1, String myString1)
        {
            this.myInt1 = myInt1;
            this.myString1 = myString1;
        }

        public MyClass(int myInt1)
        {
            this.myInt1 = myInt1;
            //this.myString1 = myString1;
        }

        public void PrintPrivateFields()
        {
            Console.WriteLine($"Int = {myInt2}, String = {myString2}");
        }

        public String InstanceMethod()
        {
            return myString2;
        }

        public void refMethod(ref int x)
        {
            x = x + 100;
            Console.WriteLine(x);
        }

        public void ValueMethod(int x)
        {
            x = x + 222;
            Console.WriteLine(x);
        }

        public int OutMethod(int number, out int outVar)
        {
            Console.WriteLine(number);
            outVar = number + 333;
            number *= number;
            return number;
        }

        public void ParameterArrayMethod(String s, params int[] arg)
        {
            foreach (var ints in arg)
            {
                if (ints == 0)
                {
                    Console.WriteLine("It's a 0!!");
                } 
            }
        }

        public int returnDouble(int x)
        {
            return x += x;
           
        }
    }
}
