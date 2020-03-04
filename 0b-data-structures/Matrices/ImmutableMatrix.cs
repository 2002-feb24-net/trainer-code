using System;

namespace Matrices
{
    class ImmutableMatrix
    {
        int[,] _data;

        ImmutableMatrix(int[,] data)
        {
            _data = new int[data.GetLength(0), data.GetLength(1)];
            Array.Copy(data, _data, data.Length);
            // copy the array, so that other code can't possibly have
            // access to _data.
        }

        public ImmutableMatrix Add(ImmutableMatrix other)
        {
            // for now, just assuming the matrices are the same size.

            int[,] resultData = new int[_data.GetLength(0), _data.GetLength(1)];

            for (int i = 0; i < _data.GetLength(0); i++)
            {
                for (int j = 0; j < _data.GetLength(1); j++)
                {
                    resultData[i, j] = _data[i, j] + other._data[i, j];
                }
            }

            return new ImmutableMatrix(resultData);
        }
    }
}