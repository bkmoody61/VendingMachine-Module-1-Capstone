using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Views
{
    public class MainMenu : ConsoleMenu // inherits from ConsoleMenu 
    {
        // Properties

        private VendingMachine VendingMachine;
        //private ProductSelector ProductSelector;


        // Constructor
        public MainMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;



            ConsoleMenu mainMenu = new ConsoleMenu();                   // new menu is created named mainMenu
            mainMenu.AddOption("Display Vending Machine Items", DisplayVendingItems)
                    .AddOption("Purchase", DisplayPurchaseMenu)
                    .AddOption("Exit", Exit);
            

            mainMenu.Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Green;
                cfg.SelectedItemForegroundColor = ConsoleColor.DarkCyan;
                cfg.Title = "Main Menu";
            });

            mainMenu.Show();

        }

        private MenuOptionResult DisplayVendingItems()
        {
            VendingMachine.DisplayInventory();                      // Calls DisplayInventory method from the VendingMachine class
            return MenuOptionResult.WaitAfterMenuSelection;

        }


        // When DisplayPurchaseMenu is called, it creates and shows a new method named purchaseMenu, 
        // which passes through the VendingMachine Class
        private MenuOptionResult DisplayPurchaseMenu()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu(VendingMachine); 
            purchaseMenu.Show();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

    }
}
