using System;
using System.Collections.Generic;
using System.Linq;
​
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            int[] ints1 = { 5, 3, 9, 7, 5, 9, 3, 7 };
            int[] ints2 = { 8, 3, 6, 4, 4, 9, 1, 0 };
            Print(ints1);
            Print(ints2);

            Array.Sort(ints1);
            Array.Sort(ints2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Print(ints1);
            Print(ints2);
            Console.ResetColor();
            Console.WriteLine();

            var list = Union(ints1, ints2).Distinct().ToArray();
            Print(list);
        }
​
        static List<int> Union(int[] array1, int[] array2)
        {
            var list = new List<int>();

            foreach (var i in array1)
            {
                foreach (var i1 in array2)
                {
                    if (i == i1) list.Add(i);
                }
            }
​
            return list;
        }
​
        static void Print(List<int> array)
        {
            foreach (var i in array)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
        }
        static void Print(int[] array)
        {
            foreach (var i in array)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
        }
    }
}