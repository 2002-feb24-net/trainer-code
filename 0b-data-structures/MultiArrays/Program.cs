using System;

namespace MultiArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // you can make an array that would contain any type
            // you can make an array of arrays

            // for example, for two dimensional image data
            string[][] image = new string[4][];
            image[0] = new string[] { "black", "black", "black", "black" };
            image[1] = new string[] { "black", "red", "red", "black" };
            image[2] = new string[] { "black", "red", "red", "black", "blue" };
            image[3] = new string[] { "black", "black", "black", "black" };
            string topRightCorner = image[0][3]; // the fourth item in the first array

            // 4x3 image with null contents at each spot (because we aren't giving it any non default value)
            string[][] secondImage = new string[4][];

            secondImage[0] = new string[3];
            secondImage[1] = new string[3];
            secondImage[2] = new string[3];
            secondImage[3] = new string[3];

            // what we have up there is "array of array" sometimes called jagged array.
            // this here is something different, it does enforce "rectangular" multi-dimensional array.
            string[,] image3 = new string[4, 4]
            {
                { "black", "black", "black", "black" },
                { "black", "red", "red", "black" },
                { "black", "red", "red", "black" },
                { "black", "black", "black", "black" }
            };
            string topRightCorner3 = image3[0, 3];
        }
    }
}
