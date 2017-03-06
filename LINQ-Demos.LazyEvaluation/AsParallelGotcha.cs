using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static System.Console;

namespace LINQ_Demos
{
    public static class AsParallelGotcha
    {
        static IEnumerable<int> numbers = Enumerable.Range(0, 100000);
        public static void Run()
        {
            ParallelMath();
            SequentialMath();
        }

        private static void ParallelMath()
        {
            WriteLine($"PLINQ:");
            for (int i = 0; i < 5; i++)
            {
                WriteLine(numbers.AsParallel()/*.AsOrdered()*/.Select(x => x * 2)
                    .Aggregate(
                    seed: 100000,
                    func: (accumulator, x) => accumulator + (accumulator / (x + 1))
                    ));
            }

        }

        private static void SequentialMath()
        {
            WriteLine($"LINQ:");
            for (int i = 0; i < 5; i++)
            {
                WriteLine(numbers.Select(x => x * 2)
                    .Aggregate(
                    seed: 100000,
                    func: (accumulator, x) => accumulator + (accumulator / (x + 1))
                    ));
            }
        }

    }
}
