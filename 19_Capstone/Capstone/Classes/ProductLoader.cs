using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class ProductLoader
    {
        public static Dictionary<string, Product> MainLoader()
        { 
           Dictionary<string, Product> ProductDictionary = new Dictionary<string, Product>();

           string filePath = @"..\..\..\Data\vendingmachine.csv";

            try
            {

                using (StreamReader fileReader = new StreamReader(filePath))
                {
                    while (!fileReader.EndOfStream)
                    {
                        string input = fileReader.ReadLine();
                        string[] fields = input.Split("|");
                        string slot = fields[0];
                        string name = fields[1];
                        decimal price = decimal.Parse(fields[2]);
                        string category = fields[3];
                        int quantity = 5;
                        Product product = new Product(name, price, category, quantity);
                        ProductDictionary.Add(slot, product);

                    }
                   
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine($"There was an error loading the inventory file: {exception.Message}");
            }
            return ProductDictionary;
        }




}
}


//public List<Product> MainLoader()
//{


//    string filePath = @"..\..\..\Data\vendingmachine.csv";

//    List<Product> products = new List<Product>();


//    using (StreamReader fileReader = new StreamReader(filePath))
//    {
//        while (!fileReader.EndOfStream)
//        {
//            string input = fileReader.ReadLine();
//            string[] fields = input.Split("|");
//            string slot = fields[0];
//            string name = fields[1];
//            decimal price = decimal.Parse(fields[2]);
//            string category = fields[3];
//            Product product = new Product(slot, name, price, category);
//            products.Add(product);

//        }

//    }
//    return products;