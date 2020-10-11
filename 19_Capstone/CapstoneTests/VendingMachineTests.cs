using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CapstoneTests

/*        
 *        public decimal MoneyFeeder(int deposit)
    {
        string feedMoney = "FEED MONEY:";
        decimal initialBalance = Balance;
        Balance += deposit;
        TransactionLog(feedMoney, initialBalance);
        return Balance;

    }*/
{
    [TestClass]
    public class VendingMachineTests
    {
        [DataTestMethod]
        [DataRow(5, 5.00, DisplayName = "5 dollar deposit attempted")]
        [DataRow(0, 0.00, DisplayName = "0 dollar deposit attempted")]
        [DataRow(-2, 0.00, DisplayName = "-2 dollar deposit attempted")]


        public void MoneyFeederTest1(int input, double expected)
        {
            //Arrange

            VendingMachine test = new VendingMachine();


            //Act

            decimal inputResult = Convert.ToDecimal(input);
            decimal expectedResult = Convert.ToDecimal(expected);
            decimal actual = test.MoneyFeeder((int)inputResult);



            //Assert
            Assert.AreEqual(expectedResult, actual);


        }


      
        [TestMethod]
        public void ProductSelectorTest1()
        {
            // Arrange
            VendingMachine test = new VendingMachine();

            string code = "A1";

            // test.Inventory[code].Quantity = 5; (not needed) 


            // Act
            test.MoneyFeeder(5);
            test.ProductSelector(code);
           

            // Assert
            Assert.AreEqual(4, test.Inventory[code].Quantity);

        }


        //[TestMethod]
        //public void ProductSelectorTest2()
        //{
        //    //Arrange
        //   VendingMachine test = new VendingMachine();

        //    string code = "a1";


        //    //Act
        //        test.MoneyFeeder(5);
        //    test.ProductSelector(code);

        //    //Assert
        //    Assert.ThrowsException<KeyNotFoundException>(() => test.ProductSelector(code));



        //}


        /* -- COMPLETE TRANSACTION -- 
         * string giveChange = "GIVE CHANGE:";
            decimal initialBalance = Balance;
            Balance -= Balance;
            TransactionLog(giveChange, initialBalance);
        */

        [TestMethod]
        public void CompleteTransactionTest()
        {
            //Arrange
            VendingMachine test = new VendingMachine();


            //Act



            // Arrange 
        }



    }
}
