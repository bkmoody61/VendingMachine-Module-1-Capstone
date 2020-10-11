using Capstone.Classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Capstone.Views
{
    public class PurchaseMenu : ConsoleMenu
    {


        private VendingMachine VendingMachine;

        public PurchaseMenu(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;



            AddOption("Feed Money", FeedMoney)
                    .AddOption("Select Product", SelectProduct)
                    .AddOption("Finish Transaction", FinishTransaction);


            Configure(cfg =>
            {
                cfg.Title = "Purchase Menu";
            });


        }

        protected override void OnBeforeShow()
        {
            Console.WriteLine($"Balance: {VendingMachine.Balance:C}");
        }
        private MenuOptionResult FeedMoney()
        {
            int money = GetInteger("Enter your deposit");
            decimal newbalance = VendingMachine.MoneyFeeder(money);
            Console.WriteLine($"Your new balance is {newbalance:C}");
            return MenuOptionResult.WaitAfterMenuSelection;

        }
        private MenuOptionResult SelectProduct()
        {
            string code = GetString("Enter product slot location:");
            //VendingMachine.ProductSelector(code);
            Console.WriteLine(VendingMachine.ProductSelector(code));
            Console.WriteLine(VendingMachine.Dispense(code));
            return MenuOptionResult.WaitAfterMenuSelection;

        }
        private MenuOptionResult FinishTransaction()
        {

            Console.WriteLine($"Your change is {VendingMachine.Balance:C}");
            Console.WriteLine(VendingMachine.CompleteTransaction());
            return MenuOptionResult.WaitThenCloseAfterSelection;

        }

    }
}
