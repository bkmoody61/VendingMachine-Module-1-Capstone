using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Views
{
    public class MainMenu : ConsoleMenu // inherits ConsoleMenu 
    {

        private VendingMachine VendingMachine;


        public MainMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;



            ConsoleMenu mainMenu = new ConsoleMenu();
            mainMenu.AddOption("Display Vending Machine Items", DisplayVendingItems)
                    .AddOption("Purchase", Purchase)
                    .AddOption("Exit", Exit);
            

            mainMenu.Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Green;
                cfg.SelectedItemForegroundColor = ConsoleColor.DarkCyan;
                cfg.Title = "Main Menu";
            });

            mainMenu.Show();

        }

        private static MenuOptionResult DisplayVendingItems()
        {
            ProductLoader product1 = new ProductLoader();
            Console.WriteLine($"{product1} test 123");
            return MenuOptionResult.DoNotWaitAfterMenuSelection;

        }

        private static MenuOptionResult Purchase()
        {
            Console.WriteLine("Hello World!");
            return MenuOptionResult.ExitAfterSelection;
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
