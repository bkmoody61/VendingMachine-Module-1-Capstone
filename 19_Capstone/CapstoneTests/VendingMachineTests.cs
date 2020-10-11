using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CapstoneTests

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

            // Act
            test.MoneyFeeder(5);
            string actualResult = test.ProductSelector(code);
            string expectedResult = "Transaction complete.";

            // Assert
            Assert.AreEqual(4, test.Inventory[code].Quantity);
            Assert.AreEqual(1.95M, test.Balance);
            Assert.AreEqual(expectedResult, actualResult);

        }


        [TestMethod]
        public void ProductSelectorTest2()
        {
            //Arrange
            VendingMachine test = new VendingMachine();
            string code = "a1";

            //Act
            test.MoneyFeeder(5);
            string actualResult = test.ProductSelector(code);
            string expectedResult = "Slot location not found.";

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(5, test.Balance);
           // Not testing inventory becuase there is no inventory at "a1."


        }

        [TestMethod]
        public void ProductSelectorTest3()
        {
            //Arrange
            VendingMachine test = new VendingMachine();
            string code = "A1";

            //Act
            test.MoneyFeeder(0);
            string actualResult = test.ProductSelector(code);
            string expectedResult = "Please deposit more money or make another selection.";

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(5, test.Inventory[code].Quantity);
            Assert.AreEqual(0M, test.Balance);

        }

        [TestMethod]
        public void ProductSelectorTest4()
        {
            //Arrange
            VendingMachine test = new VendingMachine();
            string code = " ";

            //Act
            test.MoneyFeeder(5);
            string actualResult = test.ProductSelector(code);
            string expectedResult = "Slot location not found.";

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(5, test.Balance);
            // Not testing inventory becuase there is no inventory at "."

        }

        [TestMethod]
        public void ProductSelectorTest5()
        {
            // Arrange
            VendingMachine test = new VendingMachine();
            string code = "B1";

            // Act
            test.MoneyFeeder(5);
            test.ProductSelector(code);
            string actualResult = test.ProductSelector(code);
            string expectedResult = "Transaction complete.";



            // Assert
            Assert.AreEqual(3, test.Inventory[code].Quantity);
            Assert.AreEqual(1.40M, test.Balance);
            Assert.AreEqual(expectedResult, actualResult);



        }

        [TestMethod]
        public void ProductSelectorTest6()
        {
            // Arrange
            VendingMachine test = new VendingMachine();
            string code = "D1";

            // Act
            test.MoneyFeeder(5);
            test.ProductSelector(code);
            test.ProductSelector(code);
            test.ProductSelector(code);
            test.ProductSelector(code);
            test.ProductSelector(code);
            string actualResult = test.ProductSelector(code);
            string expectedResult = "SOLD OUT";



            // Assert
            Assert.AreEqual(0, test.Inventory[code].Quantity);
            Assert.AreEqual(.75M, test.Balance);
            Assert.AreEqual(expectedResult, actualResult);



        }



        [TestMethod]
        public void DispenseTest1()
        {
            // Arrange
            VendingMachine test = new VendingMachine();
            string code = "A1";

            // Act
            test.MoneyFeeder(5);
            string actualResult = test.Dispense(code);
            string expectedResult = "Crunch Crunch, Yum!";

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void DispenseTest2()
        {
            // Arrange
            VendingMachine test = new VendingMachine();
            string code = "B1";

            // Act
            test.MoneyFeeder(5);
            string actualResult = test.Dispense(code);
            string expectedResult = "Munch Munch, Yum!";

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }
        
        [TestMethod]
        public void DispenseTest3()
        {
            // Arrange
            VendingMachine test = new VendingMachine();
            string code = "a$";

            // Act
            test.MoneyFeeder(5);
            string actualResult = test.Dispense(code);
            string expectedResult = "Please enter a capital letter followed by a number.";

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void CompleteTransationTest1()
        {
            // Arrange
            VendingMachine test = new VendingMachine();

            // Act
            test.MoneyFeeder(4);
            string actualResult = test.CompleteTransaction();
            string expectedResult = "Vending machine has dispensed 16 quarters, 0 dimes, and 0 nickels.  Please take your change.";

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(0, test.Balance);

        }

        [TestMethod]
        public void CompleteTransationTest2()
        {
            // Arrange
            VendingMachine test = new VendingMachine();

            // Act
            test.MoneyFeeder(-2);
            string actualResult = test.CompleteTransaction();
            string expectedResult = "Vending machine has dispensed 0 quarters, 0 dimes, and 0 nickels.  Please take your change.";

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(0, test.Balance);

        }

        [TestMethod]
        public void CompleteTransationTest3()
        {
            // Arrange
            VendingMachine test = new VendingMachine();

            // Act
            test.MoneyFeeder(5);
            test.ProductSelector("D1");
            string actualResult = test.CompleteTransaction();
            string expectedResult = "Vending machine has dispensed 16 quarters, 1 dimes, and 1 nickels.  Please take your change.";

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(0, test.Balance);

        }

        [TestMethod]
        public void CompleteTransationTest4()
        {
            // Arrange
            VendingMachine test = new VendingMachine();

            // Act
            test.MoneyFeeder(5);
            test.ProductSelector("d1");
            string actualResult = test.CompleteTransaction();
            string expectedResult = "Vending machine has dispensed 20 quarters, 0 dimes, and 0 nickels.  Please take your change.";

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(0, test.Balance);

        }


    }
}

