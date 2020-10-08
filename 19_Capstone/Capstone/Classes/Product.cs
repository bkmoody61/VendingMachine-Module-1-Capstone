using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
       
        // Properties
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        ///public string Slot { get; set; }

        //public int Quantity { get; set; } // Should quantity be part of the Product or assigned in the vending
        // machine.

        // Constructors

        public Product(string name, decimal price, string category)
        {
            //Slot = slot;
            Name = name;
            Price = price;
            Category = category;
            
        }
    }
}
