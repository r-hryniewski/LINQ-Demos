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
    public class ToList
    {
        IEnumerable<int> numbers = Enumerable.Range(0, 100000);


        [Benchmark]
        public void ToListTest()
        {
            numbers.Select(x => x / 2).ToList()
                .OrderByDescending(x => x).ToList()
                .Select(x => $"{x}.{x}").ToList()
                .SelectMany(x => x.Split('.')).ToList()
                .Select(x => long.Parse(x)).ToList()
                .Select(x => x / Math.PI).ToList()
                .Distinct().ToList()
                .Average();
        }

        [Benchmark]
        public void EnumerableTest()
        {
            numbers.Select(x => x / 2)
                .OrderByDescending(x => x)
                .Select(x => $"{x}.{x}")
                .SelectMany(x => x.Split('.'))
                .Select(x => long.Parse(x))
                .Select(x => x / Math.PI)
                .Distinct()
                .Average();
        }
    }
}
