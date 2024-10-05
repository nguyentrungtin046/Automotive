/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created:04-03-2024
 * Updated:04-03-2024
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Business.Tin.Nguyen;

namespace Test.Business.Tin.Nguyen
{
    [TestClass]
    public class VehicleTest
    {
        /*
         * Vehicle Constructor
         */

        [TestMethod]
        public void Constructor_YearIsLessThanMinimumYear_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            int year = 1940;
            string model = "Honda Civic";
            string manufacturer = "Honda";
            PaintColor color = PaintColor.White;
            decimal salePrice = 20000;

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Vehicle(year, model, manufacturer, color, salePrice)
                );

            // Assert
            Assert.AreEqual("year", exception.ParamName);
            Assert.AreEqual("The year must be in the range of 1950 to 2025.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_YearIsGreaterThanMaximumYear_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            int year = 2030;
            string model = "Honda Civic";
            string manufacturer = "Honda";
            PaintColor color = PaintColor.White;
            decimal salePrice = 20000;

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Vehicle(year, model, manufacturer, color, salePrice)
                );

            // Assert
            Assert.AreEqual("year", exception.ParamName);
            Assert.AreEqual("The year must be in the range of 1950 to 2025.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_ManufacturerContainOnlyWhitespaceCharacter_ThrowArgumentException()
        {
            // Arrange
            int year = 2020;
            string model = "Honda Civic";
            string manufacturer = "      ";
            PaintColor color = PaintColor.White;
            decimal salePrice = 20000;

            // Act
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(
                () => new Vehicle(year, model, manufacturer, color, salePrice)
                );

            // Assert
            Assert.AreEqual("manufacturer", exception.ParamName);
            Assert.AreEqual("The manufacturer must contain non-whitespace characters.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_ModelContainOnlyWhitespaceCharacter_ThrowArgumentException()
        {
            // Arrange
            int year = 2020;
            string model = "    ";
            string manufacturer = "Honda";
            PaintColor color = PaintColor.White;
            decimal salePrice = 20000;

            // Act
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(
                () => new Vehicle(year, model, manufacturer, color, salePrice)
                );

            // Assert
            Assert.AreEqual("model", exception.ParamName);
            Assert.AreEqual("The model must contain non-whitespace characters.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_SalePriceIsLessThan0_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            int year = 2020;
            string model = "Honda Civic";
            string manufacturer = "Honda";
            PaintColor color = PaintColor.White;
            decimal salePrice = -20000;

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Vehicle(year, model, manufacturer, color, salePrice)
                );

            // Assert
            Assert.AreEqual("salePrice", exception.ParamName);
            Assert.AreEqual("The salePrice must be 0 or greater.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_SpecifiedYearAndModelAndManufacturerAndColorAndSalePrice_InitializeState()
        {
            // Arrange
            int year = 2020;
            string model = "Honda Civic";
            string manufacturer = "Honda";
            PaintColor color = PaintColor.White;
            decimal salePrice = 20000;

            // Act
            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);

            // Assert
            PrivateObject target = new PrivateObject(vehicle);

            int actualYear = (int)target.GetProperty("Year");
            string actualModel = (string)target.GetProperty("Model");
            string actualManufacturer = (string)target.GetProperty("Manufacturer");
            PaintColor actualColor = (PaintColor)target.GetProperty("Color");
            decimal actualSalePrice = (decimal)target.GetProperty("SalePrice");

            Assert.AreEqual(year, actualYear);
            Assert.AreEqual(model, actualModel);
            Assert.AreEqual(manufacturer, actualManufacturer);
            Assert.AreEqual(color, actualColor);
            Assert.AreEqual(salePrice, actualSalePrice);
        }

        /*
         * ToString method
         */

        [TestMethod]
        public void ToString_ReturnStringRepresentation()
        {
            // Arrange
            int year = 2020;
            string model = "Honda Civic";
            string manufacturer = "Honda";
            PaintColor color = PaintColor.White;
            decimal salePrice = 20000;

            Vehicle vehicle = new Vehicle(year, model, manufacturer, color, salePrice);

            // Act
            string actual = vehicle.ToString();
            string expected = "2020, Honda, Honda Civic, White";

            // Assert
            Assert.AreEqual(expected, actual);
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
