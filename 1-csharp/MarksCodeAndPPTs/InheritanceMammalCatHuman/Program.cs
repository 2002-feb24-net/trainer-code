using System;

namespace InheritanceMammalCatHuman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //make a mammal
            //NOOOOOOOO!!!!!

            //make a human
            Human joey = new Human();
            joey.favColor = "blue";
            joey.breathsWith = "pizza";
            joey.avgHeartRate = 50;
            joey.hasFur = true;

            Console.WriteLine($"Joeys fav color is {joey.favColor}.\n He breathes with {joey.breathsWith}, \nHis heartrate is {joey.GetAvgHeartRate()}, \nand Joey has fur? == {joey.hasFur}");


            //make a cat
            Cat garfield = new Cat(true, 4, 128, "Cat Food");

            Console.WriteLine($"Garfield says... {garfield.Says()}");



            //set the unique cat characteristic


            //set the unique human characteristic


            //get the unique cat characteristic


            //get the unique chuman characteristic


            //call the unique cat action


            //call the unique human action


            //which type of inheritance is this?
            //hierarchical

            //change the cats heartrate



        }
    }
}
