using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {

        public Dictionary<string, Product> Inventory { get; set; }

        public VendingMachine (Dictionary<string, Product> inventory)
        {
            Inventory = inventory;
        }


        // Feed Money
        //decimal balance = 0.00M;
        //public decimal MoneyFeeder(decimal deposit)
        //{
        //    if (deposit == Math.Round(deposit))
        //    {
        //        balance += deposit;
        //    }
        //    return balance;
        //}


        //Select Product

        string code;
        public void ProductSelector()
        {
            if (!Inventory.ContainsKey(code))
            {
                Console.WriteLine("You did not enter a valid location"); //Did not enter a valid code
            }
            else if (Inventory[code].Quantity < 1)  // if quantity is less than 1.  Sold Out.
            {
                Console.WriteLine("Item sold out");
            }
            else
            {
                Dispense();
                Inventory[code].Quantity--;
            }
          
        }

        public void Dispense()
        {
            // print name, cost, and money remaining
            Console.WriteLine($"{Inventory[code].Name}, {Inventory[code].Price}, {remainingMoney}");
            if(Inventory[code].Category == "Chip")
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

    }
}
