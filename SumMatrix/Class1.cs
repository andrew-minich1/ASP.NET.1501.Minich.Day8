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

        public static Matrix<T> SumMatrix<T>(this Matrix<T> matrix, Matrix<T> otherMatrix)
        {
            if (matrix.Rows != otherMatrix.Rows && matrix.Columns != otherMatrix.Columns) throw new InvalidOperationException();
            Matrix<T> newMatrix = new Matrix<T>(matrix.Rows, matrix.Columns);
            Func<T, T, T> addMethod = CreateAdd<T>();
            for (int i = 0; i < matrix.Rows; i++)
            {
                for(int y = 0; y < matrix.Columns; y++)
                {
                    newMatrix[i, y] = addMethod(matrix[i, y], otherMatrix[i, y]);
                }
            }
                return newMatrix;
        }
    }
}
