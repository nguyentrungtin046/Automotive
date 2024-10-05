/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created:04-03-2024
 * Updated:07-03-2024
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Business.Tin.Nguyen;
using System.Collections.Generic;

namespace Test.Business.Tin.Nguyen
{
    [TestClass]
    public class VehicleQuoteTest
    {
        /*
         * VehicleQuote constructor.
         */

        [TestMethod]
        public void Constructor_TaxRateIsLessThan0_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal taxRate = -1m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new VehicleQuote(taxRate, vehicle, tradeInValue)
                );

            // Assert
            Assert.AreEqual("taxRate", exception.ParamName);
            Assert.AreEqual("The taxRate must be within the range of 0 to 1 (inclusive).", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_TaxRateIsGreaterThan1_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal taxRate = 2m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new VehicleQuote(taxRate, vehicle, tradeInValue)
                );

            // Assert
            Assert.AreEqual("taxRate", exception.ParamName);
            Assert.AreEqual("The taxRate must be within the range of 0 to 1 (inclusive).", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_VehicleIsNull_ThrowNullReferenceException()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = null;
            decimal tradeInValue = 5000m;

            // Act & Assert
            NullReferenceException exception = Assert.ThrowsException<NullReferenceException>(
                () => new VehicleQuote(taxRate, vehicle, tradeInValue)
                );
        }

        [TestMethod]
        public void Constructor_TradeInValueIsLessThan0_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = -5000m;

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new VehicleQuote(taxRate, vehicle, tradeInValue)
                );

            // Assert
            Assert.AreEqual("tradeInValue", exception.ParamName);
            Assert.AreEqual("The tradeInValue must be 0 or greater.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_OmitTradeInValue_InitializeState()
        {
            // Arrange 
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);

            // Act
            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle);

            // Assert
            PrivateObject target;

            target = new PrivateObject(vehicleQuote, new PrivateType(typeof(Quote)));

            decimal actualTaxRate = (decimal)target.GetProperty("TaxRate");
            decimal actualSalePrice = (decimal)target.GetField("salePrice");

            target = new PrivateObject(vehicleQuote);

            Vehicle actualVehicle = (Vehicle)target.GetField("vehicle");
            decimal actualTradeInValue = (decimal)target.GetField("tradeInValue");
            List<VehicleOption> actualListOption = (List<VehicleOption>)target.GetField("options");

            Assert.AreEqual(taxRate, actualTaxRate);
            Assert.AreEqual(20000, actualSalePrice);
            Assert.AreEqual(vehicle, actualVehicle);
            Assert.AreEqual(0, actualTradeInValue);
            Assert.IsNotNull(actualListOption);
        }

        [TestMethod]
        public void Constructor_ValidAttribute_InitializeState()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            // Act
            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Assert
            PrivateObject target;

            target = new PrivateObject(vehicleQuote, new PrivateType(typeof(Quote)));

            decimal actualTaxRate = (decimal)target.GetProperty("TaxRate");
            decimal actualSalePrice = (decimal)target.GetField("salePrice");

            target = new PrivateObject(vehicleQuote);

            Vehicle actualVehicle = (Vehicle)target.GetField("vehicle");
            decimal actualTradeInValue = (decimal)target.GetField("tradeInValue");
            List<VehicleOption> actualListOption = (List<VehicleOption>)target.GetField("options");

            Assert.AreEqual(taxRate, actualTaxRate);
            Assert.AreEqual(vehicle, actualVehicle);
            Assert.AreEqual(tradeInValue, actualTradeInValue);
            Assert.AreEqual(20000, actualSalePrice);
            Assert.IsNotNull(actualListOption);
        }

        /*
         * salePrice property
         */

        [TestMethod]
        public void GetSalePrice_ReturnTheState()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            decimal actual = vehicleQuote.SalePrice;

            // Assert
            Assert.AreEqual(20000, actual);
        }

        [TestMethod]
        public void SetSalePrice_ValueIsLessThan0_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => vehicleQuote.SalePrice = -50
                );

            // Assert
            Assert.AreEqual("value", exception.ParamName);
            Assert.AreEqual("The value must be greater than 0.", GetExceptionMessage(exception.Message));

            // Ensure the state is not updated
            PrivateObject target = new PrivateObject(vehicleQuote, new PrivateType(typeof(Quote)));

            decimal actualSalePrice = (decimal)target.GetField("salePrice");

            Assert.AreEqual(20000, actualSalePrice);
        }

        [TestMethod]
        public void SetSalePrice_ValueIs0_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => vehicleQuote.SalePrice = 0
                );

            // Assert
            Assert.AreEqual("value", exception.ParamName);
            Assert.AreEqual("The value must be greater than 0.", GetExceptionMessage(exception.Message));

            // Ensure the state is not updated
            PrivateObject target = new PrivateObject(vehicleQuote, new PrivateType(typeof(Quote)));

            decimal actualSalePrice = (decimal)target.GetField("salePrice");

            Assert.AreEqual(20000, actualSalePrice);
        }

        [TestMethod]
        public void SetSalePrice_ValueIs100_UpdateTheState()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            decimal expected = 100;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            vehicleQuote.SalePrice = expected;

            // Assert
            PrivateObject target =  new PrivateObject(vehicleQuote, new PrivateType(typeof(Quote)));

            decimal actualSalePrice = (decimal)target.GetField("salePrice");

            Assert.AreEqual(expected, actualSalePrice);
        }

        /*
         * Vehicle property
         */

        [TestMethod]
        public void GetVehicle_ReturnTheState()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            Vehicle actual = vehicleQuote.Vehicle;

            // Assert
            Assert.AreEqual(vehicle, actual);
        }

        [TestMethod]
        public void SetVehicle_ValueIsNull_ThrowArgumentNullException()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(
                () => vehicleQuote.Vehicle = null
                );

            // Assert
            Assert.AreEqual("value", exception.ParamName);
            Assert.AreEqual("The value must be a reference to a Vehicle.", GetExceptionMessage(exception.Message));

            // Ensure the state is not updated
            PrivateObject target = new PrivateObject(vehicleQuote);

            Vehicle actualVehicle = (Vehicle)target.GetField("vehicle");

            Assert.AreEqual(vehicle, actualVehicle);
        }

        [TestMethod]
        public void SetVehicle_ValidValue_UpdateTheState()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            Vehicle expected = new Vehicle(2022, "Accord", "Honda", PaintColor.Yellow, 25000);

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            vehicleQuote.Vehicle = expected;

            // Assert
            PrivateObject target;

            target = new PrivateObject(vehicleQuote, new PrivateType(typeof(Quote)));

            decimal actualSalePrice = (decimal)target.GetField("salePrice");

            target = new PrivateObject(vehicleQuote);

            Vehicle actualVehicle = (Vehicle)target.GetField("vehicle");

            Assert.AreEqual(expected, actualVehicle);
            Assert.AreEqual(25000, actualSalePrice);
        }

        /*
         * tradeInValue property
         */

        [TestMethod]
        public void GetTraInValue_ReturnTheState()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            decimal actual = vehicleQuote.TradeInValue;

            // Assert
            Assert.AreEqual(tradeInValue, actual);
        }

        [TestMethod]
        public void SetTradeInValue_ValueIsLessThan0_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => vehicleQuote.TradeInValue = -50
                );

            // Assert
            Assert.AreEqual("value", exception.ParamName);
            Assert.AreEqual("The value must be 0 or greater.", GetExceptionMessage(exception.Message));

            // Ensure the state is not updated
            PrivateObject target = new PrivateObject(vehicleQuote);

            decimal actualTradeInValue = (decimal)target.GetField("tradeInValue");

            Assert.AreEqual(tradeInValue, actualTradeInValue);
        }

        [TestMethod]
        public void SetTradeInValue_ValueIsGreaterThan0_UpdateTheState()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            decimal expected = 10000;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            vehicleQuote.TradeInValue = expected;

            // Assert
            PrivateObject target = new PrivateObject(vehicleQuote);

            decimal actualTradeInValue = (decimal)target.GetField("tradeInValue");

            Assert.AreEqual(expected, actualTradeInValue);
        }

        /*
         * AddVehicleOption method
         */

        [TestMethod]
        public void AddVehicleOption_OptionIsNull_ThrowArgumentNullException()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(
                () => vehicleQuote.AddVehicleOption(null)
                );

            // Assert
            Assert.AreEqual("vehicleOption", exception.ParamName);
            Assert.AreEqual("The vehicleOption must reference an object.", GetExceptionMessage(exception.Message));

            // Ensure the state is not updated
            PrivateObject target = new PrivateObject(vehicleQuote);

            List<VehicleOption> actualListOption = (List<VehicleOption>)target.GetField("options");
            int count = actualListOption.Count;

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void AddVehicleOption_OptionIsValid_UpdateTheState()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption = new VehicleOption("winter tire", 200m, 4);

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            // Act
            vehicleQuote.AddVehicleOption(vehicleOption);

            // Assert
            PrivateObject target = new PrivateObject(vehicleQuote);

            List<VehicleOption> actualListOption = (List<VehicleOption>)target.GetField("options");
            int count = actualListOption.Count;

            Assert.AreEqual(1, count);
        }

        /*
         * RemoveVehicleOption method
         */

        [TestMethod]
        public void RemoveVehicleOption_OptionIsValid_UpdateTheState()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption = new VehicleOption("winter tire", 200m, 4);

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            PrivateObject target = new PrivateObject(vehicleQuote);

            List<VehicleOption> list = new List<VehicleOption> { vehicleOption};

            target.SetField("options", list);

            List<VehicleOption> beforeListOption = (List<VehicleOption>)target.GetField("options");
            int beforeCount = beforeListOption.Count;

            // Act
            vehicleQuote.RemoveVehicleOption(vehicleOption);

            // Assert
            List<VehicleOption> afterListOption = (List<VehicleOption>)target.GetField("options");
            int afterCount = afterListOption.Count;

            Assert.AreEqual(1, beforeCount - afterCount);
        }

        /*
         * GetCopyVehicleOption method
         */

        /*
        [TestMethod]
        public void GetCopyVehicleOption_ReturnACopy()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption1 = new VehicleOption("winter tire", 200m, 4);
            VehicleOption vehicleOption2 = new VehicleOption("leather seat", 700, 2);

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            PrivateObject target = new PrivateObject(vehicleQuote);

            target.Invoke("AddVehicleOption", vehicleOption1);
            target.Invoke("AddVehicleOption", vehicleOption2);

            List<VehicleOption> expectedList = (List<VehicleOption>)target.GetField("options");

            // Act
            List<VehicleOption> actualList = vehicleQuote.GetCopyVehicleOption();

            // Assert
            CollectionAssert.AreEqual(expectedList, actualList);
        }
        */

        [TestMethod]
        public void GetCopyVehicleOption_ReturnACopy()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption1 = new VehicleOption("winter tire", 200m, 4);
            VehicleOption vehicleOption2 = new VehicleOption("leather seat", 700, 2);
            List<VehicleOption> list = new List<VehicleOption> { vehicleOption1, vehicleOption2 };

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            PrivateObject target = new PrivateObject(vehicleQuote);

            target.SetField("options", list);

            List<VehicleOption> expectedList = (List<VehicleOption>)target.GetField("options");

            // Act
            List<VehicleOption> actualList = vehicleQuote.GetCopyVehicleOption();

            // Assert
            Assert.AreNotSame(expectedList, actualList);
        }

            /*
             * GetSumVehicleOption method
             */

            [TestMethod]
        public void GetSumVehicleOption_ReturnTheTotalCostOfQuoteOption()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption1 = new VehicleOption("winter tire", 200m, 4);
            VehicleOption vehicleOption2 = new VehicleOption("leather seat", 700, 2);
            List<VehicleOption> list = new List<VehicleOption> { vehicleOption1, vehicleOption2 };

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            PrivateObject target = new PrivateObject(vehicleQuote);

            target.SetField("options", list);

            // Act
            decimal actualPrice = vehicleQuote.GetSumVehicleOption();

            // Assert
            Assert.AreEqual(2200, actualPrice);
        }

        /*
         * GetSubtotalVehicle method
         */

        [TestMethod]
        public void GetSubTotalVehicle_ReturnTheSubtotalOfTheQuote()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption1 = new VehicleOption("winter tire", 200m, 4);
            VehicleOption vehicleOption2 = new VehicleOption("leather seat", 700, 2);

            List<VehicleOption> list = new List<VehicleOption> { vehicleOption1, vehicleOption2 };

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            PrivateObject target = new PrivateObject(vehicleQuote);

            target.SetField("options", list);

            // Act
            decimal actualPrice = vehicleQuote.GetSubtotalVehicle();

            // Assert
            Assert.AreEqual(22200, actualPrice);
        }

        /*
         * GetSaleTa method
         */
        [TestMethod]
        public void GetSaleTax_ReturnTheSaleTaxOfTheQuote()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption1 = new VehicleOption("winter tire", 200m, 4);
            VehicleOption vehicleOption2 = new VehicleOption("leather seat", 700, 2);
            List<VehicleOption> list = new List<VehicleOption> { vehicleOption1, vehicleOption2 };

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            PrivateObject target = new PrivateObject(vehicleQuote);

            target.SetField("options", list);

            // Act
            decimal actualSaleTax = vehicleQuote.GetSalesTax();

            // Assert
            Assert.AreEqual(2664, actualSaleTax);
        }

        /*
         * GetTotalOfQuote method
         */

        [TestMethod]
        public void GetTotalOfQuote_ReturnTheTotalOfTheQuote()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption1 = new VehicleOption("winter tire", 200m, 4);
            VehicleOption vehicleOption2 = new VehicleOption("leather seat", 700, 2);
            List<VehicleOption> list = new List<VehicleOption> { vehicleOption1, vehicleOption2 };

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            PrivateObject target = new PrivateObject(vehicleQuote);

            target.SetField("options", list);

            // Act
            decimal actualTotalOfQuote = vehicleQuote.GetTotalOfQuote();

            // Assert
            Assert.AreEqual(24864, actualTotalOfQuote);
        }

        /*
         * GetAmountDue method
         */
  
        [TestMethod]
        public void GetAmountDue_ReturnTheAmountDueOfTheQuote()
        {
            // Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption1 = new VehicleOption("winter tire", 200m, 4);
            VehicleOption vehicleOption2 = new VehicleOption("leather seat", 700, 2);
            List<VehicleOption> list = new List<VehicleOption> { vehicleOption1, vehicleOption2 };

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            PrivateObject target = new PrivateObject(vehicleQuote);

            target.SetField("options", list);

            // Act
            decimal actualAmount = vehicleQuote.GetAmountDue();

            // Assert
            Assert.AreEqual(19864, actualAmount);
        }

        /*
         * ToString method
         */

        [TestMethod]
        public void ToString_ReturnTheStringRepresentation()
        {
            /// Arrange
            decimal taxRate = 0.12m;
            Vehicle vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);
            decimal tradeInValue = 5000m;
            VehicleOption vehicleOption1 = new VehicleOption("winter tire", 200m, 4);
            VehicleOption vehicleOption2 = new VehicleOption("leather seat", 700, 2);
            List<VehicleOption> list = new List<VehicleOption> { vehicleOption1, vehicleOption2 };

            VehicleQuote vehicleQuote = new VehicleQuote(taxRate, vehicle, tradeInValue);

            PrivateObject target = new PrivateObject(vehicleQuote);

            target.SetField("options", list);
            // Act
            string actualString = vehicleQuote.ToString();

            // Assert
            Assert.AreEqual("VehicleQuote: $19,864.00", actualString);
        }

        #region Helper Methods

        /// <summary>
        /// Helper method to obtain only the message from an Exception object.
        /// </summary>
        /// <param name="exceptionMessage">The Exception's Message state.</param>
        /// <returns>The Exception's message with the parameter omitted.</returns>
        /// <remarks>
        /// The Exception.Message property returns the Exception's message on line 1 and
        /// the parameter name on line 2. This method reads the first line and returns
        /// the message.
        /// </remarks>
        private string GetExceptionMessage(string exceptionMessage)
        {
            return new System.IO.StringReader(exceptionMessage).ReadLine();
        }

        #endregion
    }
}
