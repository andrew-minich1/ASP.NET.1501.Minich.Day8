using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public static class Fibonacci
    {
        public static IEnumerable<int> GetFibonacci(int size)
        {
            if(size < 0) throw new ArgumentOutOfRangeException();
            int previous = 0, current = 1;
            for (int i = 0; i < size; i++)
            {
                yield return previous;
                int next = previous + current;
                previous = current;
                current = next;
            }
        }
    }
}
