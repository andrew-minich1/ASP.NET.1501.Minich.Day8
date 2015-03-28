using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;

namespace Listeners
{
    #region Listeners
    public class ListenersChangeMatrix<T>
    {
        public ListenersChangeMatrix(Matrix<T> matrix)
        {
            matrix.Change += ListenerMsg;
        }
        private void ListenerMsg(Object sender, ChangeMatrixEventArgs eventArgs)
        {
            Console.WriteLine("Change occurred : [{0},{1}]", eventArgs.StringNumber, eventArgs.ColumnNumber);
        }

        public void Unregister(Matrix<T> matrix)
        {
            matrix.Change -= ListenerMsg;
        }
    }
    #endregion

}
