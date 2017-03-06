using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Nessos.LinqOptimizer.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LINQ_BenchmarkDemos
{
    public class Optimizations
    {
        IEnumerable<int> numbers = Enumerable.Range(0, 100000);


        [Benchmark]
        public void NoOptimizations()
        {
            numbers.Select(x => x.ToString())
                   .Select(x => x + "1")
                   .Select(x => long.Parse(x))
                   .Select(x => Math.Ceiling(x / Math.PI))
                   .Select(x => x * 2)
                   .Select(x => x + 1)
                   .Select(x => (long)Math.Floor(Math.Sqrt(x)))
                   .OrderByDescending(x => x)
                   .Select(x => x.ToString())
                   .Select(x => int.Parse(x))
                   .Select(x => (x % 5) * Math.PI)
                   .Select(x => Math.Truncate(x))
                   .Sum();
        }

        [Benchmark]
        public void LINQOptimizer()
        {
            var query = numbers.AsQueryExpr()
                               .Select(x => x.ToString())
                               .Select(x => x + "1")
                               .Select(x => long.Parse(x))
                               .Select(x => Math.Ceiling(x / Math.PI))
                               .Select(x => x * 2)
                               .Select(x => x + 1)
                               .Select(x => (long)Math.Floor(Math.Sqrt(x)))
                               .OrderByDescending(x => x)
                               .Select(x => x.ToString())
                               .Select(x => int.Parse(x))
                               .Select(x => (x % 5) * Math.PI)
                               .Select(x => Math.Truncate(x))
                               .Sum();

            query.Run();
        }

        [Benchmark]
        public void PLINQ()
        {
            numbers.AsParallel()
                   .Select(x => x.ToString())
                   .Select(x => x + "1")
                   .Select(x => long.Parse(x))
                   .Select(x => Math.Ceiling(x / Math.PI))
                   .Select(x => x * 2)
                   .Select(x => x + 1)
                   .Select(x => (long)Math.Floor(Math.Sqrt(x)))
                   .OrderByDescending(x => x)
                   .Select(x => x.ToString())
                   .Select(x => int.Parse(x))
                   .Select(x => (x % 5) * Math.PI)
                   .Select(x => Math.Truncate(x))
                   .Sum();
        }

        [Benchmark]
        public void PLINQWithLINQOptimizer()
        {
            var query = numbers.AsParallel().AsQueryExpr()
                   .Select(x => x.ToString())
                   .Select(x => x + "1")
                   .Select(x => long.Parse(x))
                   .Select(x => Math.Ceiling(x / Math.PI))
                   .Select(x => x * 2)
                   .Select(x => x + 1)
                   .Select(x => (long)Math.Floor(Math.Sqrt(x)))
                   .OrderByDescending(x => x)
                   .Select(x => x.ToString())
                   .Select(x => int.Parse(x))
                   .Select(x => (x % 5) * Math.PI)
                   .Select(x => Math.Truncate(x))
                   .Sum();

            query.Run();
        }

        [Benchmark]
        public void PLINQAsOrdered()
        {
            numbers.AsParallel().AsOrdered()
                   .Select(x => x.ToString())
                   .Select(x => x + "1")
                   .Select(x => long.Parse(x))
                   .Select(x => Math.Ceiling(x / Math.PI))
                   .Select(x => x * 2)
                   .Select(x => x + 1)
                   .Select(x => (long)Math.Floor(Math.Sqrt(x)))
                   .OrderByDescending(x => x)
                   .Select(x => x.ToString())
                   .Select(x => int.Parse(x))
                   .Select(x => (x % 5) * Math.PI)
                   .Select(x => Math.Truncate(x))
                   .Sum();
        }

    }
}
