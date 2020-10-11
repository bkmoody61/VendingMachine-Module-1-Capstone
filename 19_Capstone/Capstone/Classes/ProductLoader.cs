using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class ProductLoader
    {
        public static Dictionary<string, Product> MainLoader()              // method when called creates a new dictionary from reading the file found
        { 
            
           Dictionary<string, Product> ProductDictionary = new Dictionary<string, Product>();       // dictionary with a kvp of <string, Product>


            // checks for file path in local folder to read result from
           string filePath = @"..\..\..\..\vendingmachine.csv";

            try
            {
                // creates a new StreamReader, which reads from vendingmachine.csv and declares it as a string called fileReader
                using (StreamReader fileReader = new StreamReader(filePath))
                {
                    while (!fileReader.EndOfStream)         // while file is not at the end of stream, or while is still reading
                    {
                        string input = fileReader.ReadLine();           // reads each line of fileReader, declaring each line as a string 
                        string[] fields = input.Split("|");             // creates an array called fields, which splits each line with a |
                        string slot = fields[0];                        // in fields[], the first index is declared the slot (type = string)
                        string name = fields[1];                        // in fields[], the second index is declared the name (type = string) 
                        decimal price = decimal.Parse(fields[2]);       // in fields[], the third index is declared the price (type = decimal) and that element is converted to a decimal 
                        string category = fields[3];                    // in fields[], the fourth index is declared the category (type = string) 
                        int quantity = 5;                                                   // quantity is declared as 5, representing the initial inventory of each product
                        Product product = new Product(name, price, category, quantity);     // Product type is instantiated, which includes the listed variables
                        ProductDictionary.Add(slot, product);                               // the contents of field[0] (key of dictionalry) and contents of Product (value of dictionary) are added to the ProductDictionary

                    }
                   
                }
            }
            catch(Exception exception)      // If the file path or file does not exist, an exception message displays
            {
                Console.WriteLine($"There was an error loading the inventory file: {exception.Message}");
            }
            return ProductDictionary;
        }


}
}


