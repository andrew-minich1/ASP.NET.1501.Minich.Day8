using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using System.Linq.Expressions;

namespace SumMatrix
{
    public static class Class1
    {

        private static Func<T, T, T> CreateAdd<T>()
        {
            ParameterExpression lhs = Expression.Parameter(typeof(T), "lhs");
            ParameterExpression rhs = Expression.Parameter(typeof(T), "rhs");

            Expression<Func<T, T, T>> addExpr = Expression<Func<T, T, T>>.
            Lambda<Func<T, T, T>>(Expression.Add(lhs, rhs), new ParameterExpression[] { lhs, rhs });

            Func<T, T, T> addMethod = addExpr.Compile();

            return addMethod;
        }

        public static AbstractMatrix<T> SumMatrix<T>(this AbstractMatrix<T> matrix, AbstractMatrix<T> otherMatrix)
        {
            AbstractMatrix<T> newMatrix = new SquareMatrix<T>(matrix.Size);
            Func<T, T, T> addMethod = CreateAdd<T>();
            for (int i = 0; i < matrix.Size; i++)
            {
                for(int j = 0; j < matrix.Size; j++)
                {
                    newMatrix[i, j] = addMethod(matrix[i, j], otherMatrix[i, j]);
                }
            }
                return newMatrix;
        }

        public static AbstractMatrix<T> SumMatrix<T>(this DiagonalMatrix<T> matrix, DiagonalMatrix<T> otherMatrix)
        {
            AbstractMatrix<T> newMatrix = new DiagonalMatrix<T>(matrix.Size);
            Func<T, T, T> addMethod = CreateAdd<T>();
            for(int i =0; i<matrix.Size; i++)
            {
                newMatrix[i, i] = addMethod(matrix[i,i], otherMatrix[i, i]);
            }
            return newMatrix;
        }

        public static AbstractMatrix<T> SumMatrix<T>(this TriangularMatrix<T> matrix, TriangularMatrix<T> otherMatrix)
        {
            AbstractMatrix<T> newMatrix = new TriangularMatrix<T>(matrix.Size);
            Func<T, T, T> addMethod = CreateAdd<T>();
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j <=i; j++)
                {
                    newMatrix[i, i] = addMethod(matrix[i, i], otherMatrix[i, i]);
                }
            }
            return newMatrix;
        }

        public static AbstractMatrix<T> SumMatrix<T>(this TriangularMatrix<T> matrix, DiagonalMatrix<T> otherMatrix)
        {
            AbstractMatrix<T> newMatrix = new TriangularMatrix<T>(matrix.Size);
            Func<T, T, T> addMethod = CreateAdd<T>();
            for (int i = 0; i < matrix.Size; i++)
            {
                newMatrix[i, i] = addMethod(matrix[i, i], otherMatrix[i, i]);
            }
            return newMatrix;
        }
    }
}
