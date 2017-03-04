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
