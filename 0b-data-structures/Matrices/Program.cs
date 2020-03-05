using System;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            // here in the Program class,
            // you can write code to test out your
            // Matrix class

            Matrix matrix = new Matrix(2, 2);

            // | 0 0 |
            // | 0 0 |
            Console.WriteLine(matrix.ToString() + "\n");

            matrix.SetData(row: 0, col: 0, value: 2);
            matrix.SetData(row: 0, col: 1, value: 5);
            matrix.SetData(row: 1, col: 0, value: -1);
            matrix.SetData(row: 1, col: 1, value: 0);
            Console.WriteLine(matrix.ToString() + "\n");

            // whoops, i forgot what size the matrix is
            int rows = matrix.Rows;
            // int cols = matrix._cols;

            // matrix.GetRows() = 10; // error
            matrix.Rows = 5; // no error; i did implement a set, but it won't do anything


            Matrix matrix2 = new Matrix();
            // matrix2.ClearAndSetDimension(2, 2);
            matrix.Rows = 2;
            matrix.Cols = 2;
            matrix2.SetData(row: 0, col: 0, value: 1);
            matrix2.SetData(row: 0, col: 1, value: 1);
            matrix2.SetData(row: 1, col: 0, value: 1);
            matrix2.SetData(row: 1, col: 1, value: 1);
            Console.WriteLine(matrix2.ToString() + "\n");

            matrix.Add(matrix2);
            // | 3 6 |
            // | 0 1 |
            Console.WriteLine(matrix.ToString() + "\n");

            matrix.Negate();
            // | -3 -6 |
            // |  0 -1 |
            Console.WriteLine(matrix.ToString() + "\n");

            matrix.Transpose();
            // | -3  0 |
            // | -6 -1 |
            Console.WriteLine(matrix.ToString() + "\n");
        }

        void TestingImmutableMatrix()
        {
            ImmutableMatrix matrix = new ImmutableMatrix(new int[,]
            {
                {2, 3},
                {0, -1}
            });
            ImmutableMatrix matrix2 = new ImmutableMatrix(new int[,]
            {
                {0, 1},
                {1, 0}
            });

            ImmutableMatrix matrix3 = matrix.Add(matrix2);
            // | 2  4 |
            // | 1 -1 |
        }
    }

    class Triangle
    {
        int side1, side2, side3;
        public int Sides { get { return 3; } }
        public int Perimeter { get { return side1 + side2 + side3; } }
    }
}
