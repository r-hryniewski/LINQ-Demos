using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LINQ_Demos
{
    public static class FuncExpression
    {
        public static void Run()
        {
            Func<int, int> func = x => x + x;
            Expression<Func<int, int>> expression = x => x + x;

            WriteLine($"Func to string: {func.ToString()}");
            WriteLine($"Expression to string: {expression.ToString()}");
        }
    }
}
