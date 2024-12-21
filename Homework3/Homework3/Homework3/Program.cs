using System;
using System.Collections.Generic;
using System.Text;
using ListLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var list = new List();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Console.WriteLine($"Кількість елементів: {list.Count}");
            Console.WriteLine($"Елементу індексу 1: {list[1]}");

            list.Insert(1, 99);
            Console.WriteLine($"Елемент індексу 1 після вставки: {list[1]}");

            list.Remove(2);
            Console.WriteLine($"Містить елемент 2: {list.Contains(2)}");

            list.Reverse();
            Console.WriteLine("Список після реверсу: ");
            foreach (var item in list.ToArray())
                Console.WriteLine(item);

            list.Clear();
            Console.WriteLine($"Кількість після очищення {list.Count}");
        }
    }
}