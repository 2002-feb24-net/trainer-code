using System;

namespace ClassAndInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            MyClass myClass1 = new MyClass();
            Console.WriteLine(myClass1.myInt1);

            MyClass myClass2 = new MyClass(12, "This is a new string.");

            Console.WriteLine("This is the int => {0}\n This is the String=> {1}", myClass2.myInt1, myClass2.myString1);

            myClass2.PrintPrivateFields();

            Console.WriteLine(MyClass.myString3);
            String privateString = myClass2.InstanceMethod();
            Console.WriteLine(privateString);
            Console.WriteLine("test" + MyClass.myString3);

            int y = 11;
            Console.WriteLine($"ref variable y == {y}");
            myClass1.refMethod(ref y);
            Console.WriteLine($"ref variable y == {y}");

            int z = 22;
            Console.WriteLine($"value variable z == {z}");
            myClass1.ValueMethod(z);
            Console.WriteLine($"value variable z == {z}");


            //int outV;
            int outReturn = myClass1.OutMethod(33, out int outV);
            Console.WriteLine($"the outvariable is {outV}");
            Console.WriteLine($"the return of outMethod is {outReturn}");

            Console.WriteLine("Param array below");

            myClass1.ParameterArrayMethod("test", 1,2,3,4,0,9,7,6,0);

            int returnOfDouble = myClass1.returnDouble(500);
            Console.WriteLine(returnOfDouble);


        }
    }
}
