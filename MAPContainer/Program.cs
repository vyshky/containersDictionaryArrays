using System;
using System.Collections.Generic;
using System.Linq;


namespace MAPContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> addresBook = new Dictionary<string, string>();
            addresBook.Add("Рабочий", "ШАГ");
            addresBook.Add("Домашний", "г.Ижевск");

            PrintDictionary(addresBook);
            Console.WriteLine();
            PrintSortDictionary(addresBook);
        }

        static void PrintDictionary(Dictionary<string, string> dictionary)
        {
            foreach (var element in dictionary)
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }
        }
        static void PrintSortDictionary(Dictionary<string, string> dictionary)
        {
            var keys = dictionary.Keys.ToList();
            keys.Sort();
            foreach (var key in keys)
            {
                Console.WriteLine($"{key}: {dictionary[key]}");
            }
        }
    }
}
