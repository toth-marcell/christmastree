using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace christmastree
{
    public class Decoration
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public Decoration(string name, int price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}
