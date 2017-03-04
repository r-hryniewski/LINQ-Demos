using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LINQ_Demos
{
    public static class LINQDeferredExecution
    {
        private static List<Item> Items = new List<Item>()
        {
            new Item(1),
            new Item(2),
            new Item(3),
            new Item(4)
        };

        public static void Run()
        {

            var query = 
                //Items
                Item.GetItemsFromExternalSource(5)
                .Select(i => i.Process())
                .Where(i => i.Id > 2)
                ;

            query.ToList();
            //Items.Add(new Item(5));

            //WriteLine($"query Count: {query.Count()}");

            foreach(var item in query)
            {
                WriteLine(item.ToString());
            }
        }
    }
}
