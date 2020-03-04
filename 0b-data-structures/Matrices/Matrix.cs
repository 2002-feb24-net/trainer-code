using System;

namespace Matrices
{
    class Matrix
    {
        // field(s)
        // how will we store the data of this matrix
        int[,] _data;
        int _rows;
        int _cols;

        // methods
        // 1. some way to fill in the data

        // erase the current data and make a new
        // matrix with all zeroes
        public void ClearAndSetDimension(int rows, int cols)
        {
            _data = new int[rows, cols];
            _rows = rows;
            _cols = cols;
        }

        public void SetData(int row, int col, int value)
        {
            _data[row, col] = value;
        }

        public void Add(Matrix other)
        {

            // print an error if the sizes aren't the same.
            if (_rows != other._rows || _cols != other._cols)
            {
                Console.WriteLine("Incompatible matrix sizes");
                return;
            }
            else
            {
                for (int i = 0; i < _rows; i++)
                {
                    // for each row...
                    for (int j = 0; j < _cols; j++)
                    {
                        // for each column in that row
                        _data[i, j] += other._data[i, j];
                    }
                }
            }
        }

        public override string ToString()
        {
            string result = "[";
            for (int i = 0; i < _rows; i++)
            {
                result += " ";
                // for each row...
                for (int j = 0; j < _cols; j++)
                {
                    // for each column in that row
                    result += _data[i, j] + " ";
                }
                if (i < _rows - 1)
                {
                    result += "\n"; // line break character, aka newline
                    // (we want one between each line but not at the very end
                    // of the string)
                }
                else
                {
                    result += "]";
                }
            }
            return result;
        }

        // 2. some common matrix operations
        //    (matrix addition, matrix negation,
        //     multiplication, transpose)
    }
}
