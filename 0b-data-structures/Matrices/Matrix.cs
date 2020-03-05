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

        // things we can do with properties:
        // - get-only property with a backing field
        // - get-only property with some constant value
        // - property based on one field, with validation in set
        // - property based on several fields
        // - auto-implemented property (auto-property)

        // creates a hidden private backing field
        public int Data { get; set; }
        // in c#, it's bad practice to ever have public fields

        public int Cols
        {
            get { return _cols; }
            set
            {
                // great place for validation logic
                if (value > 0)
                {
                    ClearAndSetDimension(_rows, value);
                }
            }
        }

        // property
        public int Rows
        {
            get
            {
                Console.WriteLine("accessing Rows property");
                return _rows;
            }
            set
            {
                // inside a property setter, you have a special keyword "value"
                // which is what the code setting the property put to the right
                // of the equals sign.
                int incomingValue = value;
                // Console.WriteLine("setting Rows not allowed! doing nothing.");
                ClearAndSetDimension(value, _cols);
            }
        }

        // every class always has at least one constructor
        // if we don't write one ourselves,
        // there is an automatic "default constructor", which looks like:

        // public Matrix()
        // {
        // }

        // we could have that zero-parameter ctor set up some defaults:
        public Matrix()
        {
            ClearAndSetDimension(1, 1);
        }

        public Matrix(int rows, int cols)
        {
            if (rows < 1 || cols < 1)
            {
                Console.WriteLine("impossible matrix");
            }
            ClearAndSetDimension(rows, cols);
        }

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

        // 2. some common matrix operations
        //    (matrix addition, matrix negation,
        //     multiplication, transpose)

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

        public void Negate()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _data[i, j] *= -1;
                }
            }
        }

        public void Transpose()
        {
            int[,] newData = new int[_cols, _rows];
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    newData[j, i] = _data[i, j];
                }
            }
            _data = newData;

            // swap rows and cols
            int swap = _rows;
            _rows = _cols;
            _cols = swap;
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
    }
}
