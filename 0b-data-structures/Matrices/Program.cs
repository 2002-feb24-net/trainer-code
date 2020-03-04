﻿using System;

namespace Matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            // here in the Program class,
            // you can write code to test out your
            // Matrix class

            Matrix matrix = new Matrix();

            // | 0 0 |
            // | 0 0 |
            matrix.ClearAndSetDimension(2, 2);

            matrix.SetData(row: 0, col: 0, value: 2);
            matrix.SetData(row: 0, col: 1, value: 5);
            matrix.SetData(row: 1, col: 0, value: -1);
            matrix.SetData(row: 1, col: 1, value: 0);
            // |  2  5 |
            // | -1  0 |

            Matrix matrix2 = new Matrix();
            matrix2.ClearAndSetDimension(2, 2);
            matrix2.SetData(row: 0, col: 0, value: 1);
            matrix2.SetData(row: 0, col: 1, value: 1);
            matrix2.SetData(row: 1, col: 0, value: 1);
            matrix2.SetData(row: 1, col: 1, value: 1);

            // | 1 1 |
            // | 1 1 |

            matrix.Add(matrix2);
            // | 3 6 |
            // | 0 1 |
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
}
