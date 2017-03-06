using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_BenchmarkDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<ToList>();
            //BenchmarkRunner.Run<LINQvsNoLINQ>();
            BenchmarkRunner.Run<Optimizations>();
            Console.ReadKey();
        }
    }
}
