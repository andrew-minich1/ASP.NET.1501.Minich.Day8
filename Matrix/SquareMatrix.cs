using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Matrix
{
    public class Matrix<T> : IEnumerable<T>
    {

        protected T[,] matrix;
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        protected Action<int, int, T> SetValue;

        #region Constructor
        public Matrix(int columns, int rows)
        {
            if (columns < 0 || rows < 0) throw new ArgumentOutOfRangeException();
            this.matrix = new T[rows, columns];
            this.Rows = rows;
            this.Columns = columns;
            SetValue = this.MakeChanges;
        } 
        #endregion
       
        #region Indexer
        public virtual T this[int indexString, int indexColumn]
        {
            get
            {
                try
                {
                    return matrix[indexString, indexColumn];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                try
                {

                    SetValue(indexString, indexColumn, value);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        #endregion

        #region virtual
        protected virtual void MakeChanges(int indexRow, int indexColumn, T newValue)
        {
            matrix[indexRow, indexColumn] = newValue;
            this.MakeChange(indexRow, indexColumn);
        } 
        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    yield return this[i, y];
                }

            }
        }
        #endregion

        #region Event

        public event EventHandler<ChangeMatrixEventArgs> Change = delegate { };
        protected virtual void OnChanged(ChangeMatrixEventArgs e)
        {
            EventHandler<ChangeMatrixEventArgs> temp = Change;
            temp(this, e);
        }
        public void MakeChange(int stringNumber, int columnNumber)
        {
            OnChanged(new ChangeMatrixEventArgs(stringNumber, columnNumber));
        }
        #endregion

    }

    public class SquareMatrix<T> : Matrix<T>
    {
        
        #region Constructor
        public SquareMatrix(int size)
            : base(size, size) { }
        #endregion

    }

    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Constructor
        public DiagonalMatrix(int size)
            : base(size) { }
        #endregion

        #region override
        protected override void MakeChanges(int indexRow, int indexColumn, T newValue)
        {
            if (indexRow != indexColumn) throw new ArgumentOutOfRangeException();
            matrix[indexRow, indexColumn] = newValue;
        } 
        #endregion

    }

    public class TriangularMatrix<T> : SquareMatrix<T>
    {
        #region Constructor
        public TriangularMatrix(int size)
            : base(size) { }
        #endregion


        #region override
        protected override void MakeChanges(int indexRow, int indexColumn, T newValue)
        {
            matrix[indexRow, indexColumn] = newValue;
            this.MakeChange(indexRow, indexColumn);
            if (indexRow != indexColumn)
            {
                matrix[indexColumn, indexRow] = newValue;
                this.MakeChange(indexColumn, indexRow);
            }
        } 
        #endregion


    }

    public sealed class ChangeMatrixEventArgs : EventArgs
    {
        #region fields
        private readonly int stringNumber;
        private readonly int columnNumber;
        #endregion

        #region ctor
        public ChangeMatrixEventArgs(int stringNumber, int columnNumber)
        {
            this.stringNumber = stringNumber;
            this.columnNumber = columnNumber;
        }
        #endregion

        #region properties
        public int StringNumber { get { return stringNumber; } }
        public int ColumnNumber { get { return columnNumber; } }
        #endregion
    }
}
