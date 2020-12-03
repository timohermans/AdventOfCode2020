using AdventOfCode.Day1;
using AdventOfCode.Day1.Implementation;
using System;

namespace AdventOfDay.Consoled
{
    class Program
    {
        static void Main(string[] args)
        {
            var report = Data.Report;

            var finder = new MatchFinder
            {
                TotalToMatch = 2020,
                NumberOfElementsToMatch = 3
            };

            var result = finder.Find(report);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
