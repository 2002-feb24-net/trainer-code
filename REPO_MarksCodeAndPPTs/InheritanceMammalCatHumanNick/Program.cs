using System;

namespace InheritanceMammalCatHuman
{
    class Program
    {
        static void Main()
        {
            var joey = new Human(avgHeartRate: 50, favoriteColor: "blue");
            var garfield = new Cat(avgHeartRate: 128);

            Console.WriteLine(garfield.Says());
        }
    }
}
