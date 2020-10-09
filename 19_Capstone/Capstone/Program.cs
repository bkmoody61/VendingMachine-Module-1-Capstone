using Capstone.Classes;
using Capstone.Views;
using System;
using System.Collections.Generic;

namespace Capstone
{
    public class Program
    {


        static void Main(string[] args)
        {

            VendingMachine vendingMachine = new VendingMachine();
            MainMenu mainMenu = new MainMenu(vendingMachine);
            mainMenu.Show();
         

            //    ProductLoader product1 = new ProductLoader();
            //    Dictionary<string, Product>products = product1.MainLoader();
            //    foreach(var kvp in products)
            //    {
            //        Console.WriteLine(kvp.Key +" "+ kvp.Value.Name + " " + kvp.Value.Price + " " + kvp.Value.Category);
            //    }
            //    //Console.WriteLine();
            //}
        }
    }
}
