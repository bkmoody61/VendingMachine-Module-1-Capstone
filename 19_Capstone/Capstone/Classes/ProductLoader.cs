using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class ProductLoader
    {
        public Dictionary<string, Product> MainLoader()
        {


            string filePath = @"..\..\..\Data\vendingmachine.csv";

           Dictionary<string, Product> products = new Dictionary<string, Product>();


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
                    Product product = new Product(name, price, category);
                    products.Add(slot, product);

                }

            }
            return products;


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

        }




}
}

