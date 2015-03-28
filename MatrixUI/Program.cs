using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using Listeners;
using SumMatrix;

namespace MatrixUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> matrix = new TriangularMatrix<int>(3);
            ListenersChangeMatrix<int> listener = new ListenersChangeMatrix<int>(matrix);
            matrix[0, 0] = 2;
            matrix[1, 1] = 5;
            matrix[2, 2] = 3;
            matrix[0, 1] = 1;

            Matrix<int> matrix2 = new SquareMatrix<int>(3);
            matrix2[0, 0] = 2;
            matrix2[1, 1] = 5;
            matrix2[2, 2] = 3;
            matrix2[0, 1] = 1;

            Matrix<int> matrix3 = matrix2.SumMatrix(matrix);

            foreach (var x in matrix3)
            {
                Console.WriteLine(x);
            }
        }
    }
}
