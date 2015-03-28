using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class SearchAlgoritm
    {

        public static int? BinarySearch<T>(T[] array, T key, IComparer<T> comparer)
        {
            int left = 0;
            int right = array.Length-1;
            int mid = (left + right) / 2;
            int compareResult;
            while (!(left >= right))
            {
                if (ReferenceEquals(comparer, null))
                {
                    compareResult = (array[mid] as IComparable<T>).CompareTo(key);
                }
                else compareResult = comparer.Compare(array[mid], key);

                if (compareResult == 0)
                {
                    return mid;
                }
                else if (compareResult > 0)
                {
                    right = mid;
                }
                else
                {
                    left = mid+1;
                }
                mid = (left + right) / 2;
            }
            return null;
        }
    }
}
