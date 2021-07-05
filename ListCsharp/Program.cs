using System;
using System.Collections.Generic;
using System.Linq;

namespace ListCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            
            list.Add(5);
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(1);
            Print(list);
            list.Sort();
            Print(list);
            list.Reverse();
            Print(list);

            var list2 = list.Distinct().ToList();
            Print(list);

        }
        static void Print(List<int> array)
        {
            foreach (var i in array)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
        
        }static void Print(int[] array)
        {
            foreach (var i in array)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
        }
    }
}