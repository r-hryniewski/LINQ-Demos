using System;
using System.Linq;
using System.Linq.Expressions;
using static System.Console;

namespace LINQ_EFDemo
{
    class Program
    {
        static Func<Item, bool> funcPredicate = i => i.Id % 5 == 0;
        static Expression<Func<Item, bool>> exprPredicate = i => i.Id % 5 == 0;

        static void Main(string[] args)
        {
            using (var dbContext = new DemoContext())
            {
                dbContext.Items.FirstOrDefault(); //Initialize db
                Clear();

                WriteLine("Expression Predicate:");
                var items1 = dbContext.Items.Where(exprPredicate).ToList();
                ReadKey();

                WriteLine("Func Predicate:");
                var items2 = dbContext.Items.Where(funcPredicate).ToList();
            }

            ReadKey();
        }
    }
}
