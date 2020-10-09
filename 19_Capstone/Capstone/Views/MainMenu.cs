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
        // Properties

        private VendingMachine VendingMachine;
        //private ProductSelector ProductSelector;


        // Constructor
        public MainMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;



            ConsoleMenu mainMenu = new ConsoleMenu();
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
            VendingMachine.DisplayInventory();
            return MenuOptionResult.WaitAfterMenuSelection;

        }

        private MenuOptionResult DisplayPurchaseMenu()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu(VendingMachine);
            purchaseMenu.Show();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

    }
}
