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

        public decimal Balance { get; private set; } = 0; // Balance is initially set to 0

        public string LocationMessage { get; private set; } 

        public string DispenseMessage { get; private set; }


        // Constructor
        public VendingMachine()
        {
            // created a dictionary called Inventory, by calling the MainLoader function inside of the ProductLoader Class
            // (which when called creates a dictionary <string, Product>)
            Inventory = ProductLoader.MainLoader();
        }
       
        
        public void DisplayInventory()
        {
            // created a Method Display Inventory, which when called will loop through the Inventory dictionary
            foreach (var kvp in Inventory)
            {
                // prints out the keys and values of Inventory dictionary, <string, Product>, and converts the value (type Product) to a string
                Console.WriteLine(kvp.Key + " " + kvp.Value.ToString()); ;
            }
        }

        // Methods

       

        //Feed Money
        // When MoneyFeeder is called, will pass through an int and increment it if that int is > 0, otherwise return "Please enter a valid deposit"
        
        public decimal MoneyFeeder(int deposit)
        {
            if (deposit > 0)
            {
                string feedMoney = "FEED MONEY:";
                decimal initialBalance = Balance;
                Balance += deposit;
                TransactionLog(feedMoney, initialBalance);      // if int deposit is > 0, calls the method TransactionLog which passes through a string and a decimal
                return Balance;
            }
            else
            {
                Console.WriteLine("Please enter a valid deposit.");
            }
            return Balance;
        }


        //Select Product
        // when ProductSelector is called, it will pass through a string, check the inventory for that slotlocation or product, and check the balance input against the product price
        // then the location message is set, depending on each condition
        public string ProductSelector(string code)
        {
            if (!Inventory.ContainsKey(code))
            {
                LocationMessage = "Slot location not found.";
            }
            else if (Inventory[code].Quantity < 1)  // if quantity is less than 1.  Sold Out.
            {
                LocationMessage = "SOLD OUT";
            }
            else if(Balance < Inventory[code].Price)
            {
                LocationMessage = "Please deposit more money or make another selection.";
            }
            else
            {
                Dispense(code);                                                         // calls the Dispense method and passes through the string (code)
                decimal initialBalance = Balance;                                      
                Balance -= Inventory[code].Price;                                       // decrements the balance by the price (of the product purchased)
                Inventory[code].Quantity--;                                            // decrements quantity of products by 1
                LocationMessage = "Transaction complete.";                              
                TransactionLog(Inventory[code].Name + " " + code, initialBalance);    // if the slotlocation exists, inventory exists, and balance > price, calls the method TransactionLog
                                                                                       // and prints the slotlocationName, the slotlocation, and the balance

            }
            return LocationMessage;
        }


        // Dispense Method, which when called returns a string depending on the Inventory's key (or in other words the slotlocation)
        public string Dispense(string code)
        {
            if (!Inventory.ContainsKey(code))
            {
                DispenseMessage = "Please enter a capital letter followed by a number.";
            }
            else if (Inventory[code].Category == "Chip")
            {
                DispenseMessage = "Crunch Crunch, Yum!";
            }
            else if (Inventory[code].Category == "Candy")
            {
                DispenseMessage = "Munch Munch, Yum!";
            }
            else if (Inventory[code].Category == "Drink")
            {
                DispenseMessage = "Glug Glug, Yum!";
            }
            else if (Inventory[code].Category == "Gum")
            {
                DispenseMessage = "Chew Chew, Yum!";
            }
            return DispenseMessage;
        }

        // Finish Transaction
        // Complete transaction, which when called will return the coin balance as decimals, decrement the user's balance, and write to the transaction log
        public string CompleteTransaction()
        {
          
            decimal change = Balance;

            decimal quarters = 0;
            decimal dimes = 0;
            decimal nickels = 0;

            while (change >= 0.25m)
            {
                quarters = Math.Truncate((change / 0.25m));   // returns integer part of a number by removing any fractional digits
                change = change % 0.25m;                       // sets change equal to (change % .25) the remainder of the change less the portion assigned to quarters
            }

            while (change >= 0.10m)
            {
                dimes = Math.Truncate((change / 0.10m));
                change = change % 0.10m;                    // sets change equal to (change % .10) the remainder of the change less the portion assigned to dimes
            }

            while (change >= 0.05m)
            {
                nickels = Math.Truncate((change / 0.05m));
                change = change % 0.05m;                     // sets change equal to (change % .05) the remainder of the change less the portion assigned to nickels.  Should be zero.

            }
           
            string giveChange = "GIVE CHANGE:";
            decimal initialBalance = Balance;                           // assigns balance prior to dispensing change to a variable called initialBalance                            
            Balance -= Balance;                                         // decrements balance to zero.  Effectively paying the customer back.
            TransactionLog(giveChange, initialBalance);                 // calls TransactionLog, which returns a string and the remaining balance (which is 0 since all change has been given)
            return ($"Vending machine has dispensed {quarters} quarters, {dimes} dimes, and {nickels} nickels.  Please take your change.");


        }
        public void TransactionLog(string functionName, decimal initialBalance)
        {

            // Creates a file in the local folder to write the result to 
            string logPath = @"..\..\..\..\Log.txt";

            // creates a new StreamWriter called writer, which appends to the file
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                // Logs the date and time, any string that is passed through each of the methods called, the initial balance, and current balance
                writer.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} {functionName} {initialBalance:C} {Balance:C}");
            }
        }


    }
}
