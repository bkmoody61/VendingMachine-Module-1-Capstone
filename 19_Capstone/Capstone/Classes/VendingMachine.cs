using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        // Properties

        public Dictionary<string, Product> Inventory { get; set; }

        public decimal Balance { get; private set; } = 0;

        public string LocationMessage { get; private set; }

        public string DispenseMessage { get; private set; }


        // Constructor
        public VendingMachine()
        {
            Inventory = ProductLoader.MainLoader();
        }
       
        public void DisplayInventory()
        {
            foreach (var kvp in Inventory)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value.ToString()); ;
            }
        }

        // Methods

       

        //Feed Money

        public decimal MoneyFeeder(int deposit)
        {
            if (deposit > 0)
            {
                string feedMoney = "FEED MONEY:";
                decimal initialBalance = Balance;
                Balance += deposit;
                TransactionLog(feedMoney, initialBalance);
                return Balance;
            }
            else
            {
                Console.WriteLine("Please enter a valid deposit.");
            }
            return Balance;
        }


        //Select Product
        
        public string ProductSelector(string code)
        {
            if (!Inventory.ContainsKey(code))
            {
                LocationMessage = "You did not enter a valid location.";
                //Console.WriteLine("You did not enter a valid location"); //Did not enter a valid code
            }
            else if (Inventory[code].Quantity < 1)  // if quantity is less than 1.  Sold Out.
            {
                LocationMessage = "SOLD OUT";
                //Console.WriteLine("SOLD OUT");
            }
            else if(Balance < Inventory[code].Price)
            {
                LocationMessage = "Please deposit more money or make another selection.";
                //Console.WriteLine("Please deposit more money or make another selection");
            }
            else
            {
                Dispense(code);
                decimal initialBalance = Balance;
                Balance -= Inventory[code].Price;
                Inventory[code].Quantity--;
                LocationMessage = "Transaction complete.";
                TransactionLog(Inventory[code].Name + " " + code, initialBalance);
             
            }
            return LocationMessage;
        }



        public string Dispense(string code)
        {
            // print name, cost, and money remaining
            //Console.WriteLine($"{Inventory[code].Name}, {Inventory[code].Price}, {remainingMoney}");
            if (!Inventory.ContainsKey(code))
            {
                DispenseMessage = "Please select a valid location.";
            }
            else if (Inventory[code].Category == "Chip")
            {
                DispenseMessage = "Crunch Crunch, Yum!";
                //Console.WriteLine("Crunch Crunch, Yum!"); 
            }
            else if (Inventory[code].Category == "Candy")
            {
                DispenseMessage = "Munch Munch, Yum!";
                //Console.WriteLine("Munch Munch, Yum!");
            }
            else if (Inventory[code].Category == "Drink")
            {
                DispenseMessage = "Glug Glug, Yum!";
                //Console.WriteLine("Glug Glug, Yum!");
            }
            else if (Inventory[code].Category == "Gum")
            {
                DispenseMessage = "Chew Chew, Yum!";
                //Console.WriteLine("Chew Chew, Yum!");
            }
            return DispenseMessage;
        }

        // Finish Transaction
        public void CompleteTransaction()
        {
            Console.WriteLine($"Your change is {Balance:C}");

            decimal change = Balance;

            decimal quarters = 0;
            decimal dimes = 0;
            decimal nickels = 0;

            while (change >= 0.25m)
            {
                quarters = Math.Truncate((change / 0.25m));
                change = change % 0.25m;
            }

            while (change >= 0.10m)
            {
                dimes = Math.Truncate((change / 0.10m));
                change = change % 0.10m;
            }

            while (change >= 0.05m)
            {
                nickels = Math.Truncate((change / 0.05m));
                change = change % 0.05m;

            }
           
            Console.WriteLine($"Vending machine has dispensed {quarters} quarters, {dimes} dimes, and {nickels} nickels.  Please take your change.");

            string giveChange = "GIVE CHANGE:";
            decimal initialBalance = Balance;
            Balance -= Balance;
            TransactionLog(giveChange, initialBalance);
        }
        public void TransactionLog(string functionName, decimal initialBalance)
        {
            string logPath = @"..\..\..\..\Log.txt";

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} {functionName} {initialBalance:C} {Balance:C}");
            }
        }


    }
}
