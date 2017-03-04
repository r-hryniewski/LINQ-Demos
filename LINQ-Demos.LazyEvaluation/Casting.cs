using System;
using System.Linq;
using static System.Console;

namespace LINQ_Demos
{
    public class Casting
    {
        public static void Run()
        {
            var collection = new object[] { 1, 2, 3, "b" };
            var intCollection = collection.OfType<int>();
            //1, 2, 3
            var intCollection2 = collection.Cast<int>();
            //Invalid Cast Exception
            try
            {
                WriteLine(intCollection.Aggregate(string.Empty, (acc, x) => acc + $"{x} "));
            }
            catch (Exception ex)
            {

                WriteLine(ex.Message);
            }

            try
            {
                WriteLine(intCollection.Aggregate(string.Empty, (acc, x) => acc + $"{x} "));
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}