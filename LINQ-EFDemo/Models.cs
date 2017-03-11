using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_EFDemo
{
    public class Item
    {
        public string Name { get; set; }
        [Key]
        public long Id { get; set; }
    }

    public class Container
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}
