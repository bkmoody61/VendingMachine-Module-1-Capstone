﻿using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Views
{
    public class MainMenu
    {
        private VendingMachine VendingMachine;


        public MainMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;


        }
        //public void DisplayInventory()
        //{
        //    ProductLoader product1 = new ProductLoader();
        //    List<Product> products = product1.MainLoader();
        //    foreach (Product item in products)
        //    {
        //        Console.WriteLine(item.Slot + " " + item.Name + " " + item.Price + " " + item.Category);
        //    }


        //}

    }
}