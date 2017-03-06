using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LINQ_BenchmarkDemos
{
    public class LINQvsNoLINQ
    {
        int count = 1000000;
        int[] numbers;

        [Setup]
        public void Setup()
        {
            numbers = Enumerable.Range(0, count).ToArray();
        }


        [Benchmark]
        public void Linq()
        {
            numbers.Where(n => n % 6 == 0)
                .Select(n => n / 3)
                .Max();
        }

        [Benchmark]
        public void Foreach()
        {
            var max = 0;
            foreach (var n in numbers)
            {
                if (n % 6 == 0)
                {
                    var x = n / 3;
                    if (x > max)
                        max = x;
                }

            }
        }

        [Benchmark]
        public void For()
        {
            var max = 0;
            for (int i = 0; i < count; i++)
            {
                var n = numbers[i];
                if (n % 6 == 0)
                {
                    var x = n / 3;
                    if (x > max)
                        max = x;
                }
            }
        }
    }
}
