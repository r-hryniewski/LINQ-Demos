using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace LINQ_Demos
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public Item(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public Item(long id) : this(id, $"Item: {id}") { }

        public Item Process()
        {
            WriteLine($"Processing item id: {Id}");
            return this;
        }

        public override string ToString()
        {
            return $"Item Name:'{Name}' Id:'{Id}'";
        }

        public static IEnumerable<Item> GetItemsFromExternalSource(int quantity = 10)
        {
            var result = Enumerable.Range(1, quantity)
                .Select(x => 
                {
                    Console.WriteLine("External item requested");
                    Thread.Sleep(1000);
                    Console.WriteLine("External item ready after ~1 second");
                    return new Item(x);
                });
            
            return result;
        }
    }
}
