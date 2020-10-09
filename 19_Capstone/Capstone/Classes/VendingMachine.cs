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

        public decimal Balance { get; private set; }


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
           
            Balance += deposit;
            return Balance;
           
        }


        //Select Product


        public void ProductSelector(string code)
        {
            if (!Inventory.ContainsKey(code))
            {
                Console.WriteLine("You did not enter a valid location"); //Did not enter a valid code
            }
            else if (Inventory[code].Quantity < 1)  // if quantity is less than 1.  Sold Out.
            {
                Console.WriteLine("SOLD OUT");
            }
            else if(Balance < Inventory[code].Price)
            {
                Console.WriteLine("Please deposit more money or make another selection");
            }
            else
            {
                Dispense(code);
                Balance -= Inventory[code].Price;
                Inventory[code].Quantity--;
            }
          
        }

        public void Dispense(string code)
        {
            // print name, cost, and money remaining
            //Console.WriteLine($"{Inventory[code].Name}, {Inventory[code].Price}, {remainingMoney}");
            if (Inventory[code].Category == "Chip")
            {
                Console.WriteLine("Crunch Crunch, Yum!");
            }
            if (Inventory[code].Category == "Candy")
            {
                Console.WriteLine("Munch Munch, Yum!");
            }
            if (Inventory[code].Category == "Drink")
            {
                Console.WriteLine("Glug Glug, Yum!");
            }
            if (Inventory[code].Category == "Gum")
            {
                Console.WriteLine("Chew Chew, Yum!");
            }
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

        }
      

    }
}
