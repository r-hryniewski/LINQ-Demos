using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LINQ_Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            //BooleanLazyEvaluation.Run();

            //LINQDeferredExecution.Run();

            //Yield.Run();

            FuncExpression.Run();

            ReadKey();
        }
    }
}