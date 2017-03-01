using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LINQ_Demos
{
    public static class BooleanLazyEvaluation
    {
        public static void Run()
        {
            if (FirstPredicate()/*true*/ || SecondPredicate())
                WriteLine("Expression returned true");
        }

        private static bool FirstPredicate()
        {
            WriteLine("First Predicate Executed");
            return true;
        }

        private static bool SecondPredicate()
        {
            WriteLine("Second Predicate Executed");
            return true;
        }
    }
}
