using Capstone.Classes;
using Capstone.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Capstone
{
    public class Program
    {


        static void Main(string[] args)
        {

            VendingMachine vendingMachine = new VendingMachine();
            MainMenu mainMenu = new MainMenu(vendingMachine);
                    
         

          

           



        }

      
    }
}
