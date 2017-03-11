using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LINQ_EFDemo
{
    public class DemoContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Container> Containers { get; set; }

        public DemoContext()
        {
            Database.SetInitializer<DemoContext>(new DemoDBInitializer());

            Database.Log = sql => WriteLine(sql);
        }
    }
    public class DemoDBInitializer : DropCreateDatabaseAlways<DemoContext>
    {
        protected override void Seed(DemoContext context)
        {
            Container activeContainer = null;
            for (int i = 0; i < 200; i++)
            {
                if (i % 10 == 0)
                {
                    activeContainer = context.Containers.Add(new Container()
                    {
                        Id = i,
                        Name = $"Container {i}",
                        Items = new List<Item>()
                    });
                }

                var newItem = context.Items.Add(new Item()
                {
                    Name = $"Item {i}",
                    Id = i
                });

                activeContainer.Items.Add(newItem);
                base.Seed(context);
            }
        }
    }
}
