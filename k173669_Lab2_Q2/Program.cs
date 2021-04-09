using System;
using System.Collections.Generic;
using System.Linq;

namespace k173669_Lab2_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 1000000;
            int min = 0;
            int max = 1000;

            Random randomGen = new Random();
            List<int> numbers = Enumerable.Repeat(0, length).
                Select(idx => randomGen.Next(min, max)).ToList();

            Console.WriteLine(numbers.Count);

            Console.WriteLine("Hello World!");
        }
    }
}
