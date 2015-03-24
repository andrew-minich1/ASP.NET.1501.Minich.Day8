using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public static class IteratorLogic
    {

        public static IEnumerable<T> Iterator<T>(this IEnumerable<T> collection, Func<T, bool> func)
        {
            if (ReferenceEquals(collection, null) || ReferenceEquals(func,null)) throw new ArgumentNullException();
            T[] array = collection.ToArray<T>();
            for (int i = 0; i < array.Length; i++)
            {
                if (func(array[i]) == true) yield return array[i];
            }
        }

        public static IEnumerable<T> Iterator2<T>(this IEnumerable<T> collection,int number, Func<int, int> func)
        {
            if (ReferenceEquals(collection, null) || ReferenceEquals(func, null)) throw new ArgumentNullException();
            T[] array = collection.ToArray<T>();
            int i = number;
            while(i<array.Length && i>=0)
            {
                yield return array[i];
                i = func(i);
            }
        }
    }
}
