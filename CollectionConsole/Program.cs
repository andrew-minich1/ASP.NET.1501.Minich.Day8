using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collection;

namespace CollectionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
             int[] arr2 = new int[] { 1, 2, 3, 4, 5, 6 };
            char[] arrChar = new char[] { 'a', 'B', 'C', 'd', 'E' };
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            string str =  "aB12lhv78gd";
            
            foreach(var x in arr2.Iterator2<int>(0,(i)=>{return i+2;}))
            {
                Console.Write(x);
            }

            Console.WriteLine();

            foreach(var x in list.Iterator<int>((i)=>{return i>3;}))
            {
                Console.Write(x);
            }
            Console.WriteLine();

            foreach (var x in arr.Iterator<int>((i) => { return i % 2==0; }))
            {
                Console.Write(x);
            }

            Console.WriteLine();

            foreach (var x in arrChar.Iterator<char>((i) => { return Char.IsLower(i) == true; }))
            {
                Console.Write(x);
            }

            Console.WriteLine();

            foreach (var x in str.Iterator<char>((i) => { return Char.IsDigit(i) == true; }))
            {
                Console.Write(x);
            }

            Console.WriteLine();

            
        }
    }
}
