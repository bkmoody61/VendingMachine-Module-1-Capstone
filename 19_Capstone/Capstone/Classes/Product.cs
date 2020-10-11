using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
       
        // Properties
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; } 


        // Constructors

        public Product(string name, decimal price, string category, int quantity)
        {
           
            Name = name;
            Price = price;
            Category = category;
            Quantity = quantity;
            
            
        }

        // Methods

        // When ToString is called, it returns list of properties formatted with spacing
        public override string ToString()
        {
            return Name + " " + Price + " " + Category + " " + Quantity;
        }
    }
}
