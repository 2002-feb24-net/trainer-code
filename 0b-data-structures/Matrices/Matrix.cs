using System;

namespace Matrices
{
    class Matrix
    {
        // field(s)
        // how will we store the data of this matrix
        int[,] data;

        // methods
        // 1. some way to fill in the data

        // erase the current data and make a new
        // matrix with all zeroes
        public void ClearAndSetDimension(int rows, int cols)
        {
            data = new int[rows, cols];
        }

        public void SetData(int row, int col, int value)
        {
            data[row, col] = value;
        }

        public void Add(Matrix other)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            // print an error if the sizes aren't the same.
            // (GetLength will give us one of the side lengths of a multi-d array)
            bool error = (rows != other.data.GetLength(0) ||
                cols != other.data.GetLength(1));
            if (error)
            {
                Console.WriteLine("Incompatible matrix sizes");
                return;
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    // for each row...
                    for (int j = 0; j < cols; j++)
                    {
                        // for each column in that row
                        data[i, j] += other.data[i, j];
                    }
                }
            }
        }

        // 2. some common matrix operations
        //    (matrix addition, matrix negation,
        //     multiplication, transpose)
    }
}
