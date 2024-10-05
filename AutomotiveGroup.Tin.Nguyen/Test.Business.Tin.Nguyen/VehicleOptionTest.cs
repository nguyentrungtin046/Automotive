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
    public class VehicleOptionTest
    {
        /*
         * VehicleOption constructor
         */

        [TestMethod]
        public void Constructor_DescriptionContainOnlyWhitespaceCharacter_ThrowArgumentException()
        {
            // Arrange
            string description = "   ";
            decimal unitPrice = 300;
            int quantity = 4;

            // Act
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(
                () => new VehicleOption(description, unitPrice, quantity)
                );

            // Assert
            Assert.AreEqual("description", exception.ParamName);
            Assert.AreEqual("The description must contain non-whitespace characters.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_PriceIsLessThan0_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            string description = "Winter Tire";
            decimal unitPrice = -30;
            int quantity = 4;

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new VehicleOption(description, unitPrice, quantity)
                );

            // Assert
            Assert.AreEqual("unitPrice", exception.ParamName);
            Assert.AreEqual("The unitPrice must be 0 or greater.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_QuantityIsLessThan0_ThrowArgumentOutOfRangeException()
        {
            // Arrange
            string description = "Winter Tire";
            decimal unitPrice = 300;
            int quantity = -10;

            // Act
            ArgumentOutOfRangeException exception = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new VehicleOption(description, unitPrice, quantity)
                );

            // Assert
            Assert.AreEqual("quantity", exception.ParamName);
            Assert.AreEqual("The quantity must be 0 or greater.", GetExceptionMessage(exception.Message));
        }

        [TestMethod]
        public void Constructor_SpecifiedDescriptionAndUnitPriceAndQuantity()
        {
            // Arrange
            string description = "Winter Tire";
            decimal unitPrice = 300;
            int quantity = 4;

            // Act
            VehicleOption vehicleOption = new VehicleOption(description, unitPrice, quantity);

            // Assert
            PrivateObject target = new PrivateObject(vehicleOption);

            string actualDescription = (string)target.GetProperty("Description");
            decimal actualUnitPrice = (decimal)target.GetProperty("UnitPrice");
            int actualQuantity = (int)target.GetProperty("Quantity");

            Assert.AreEqual(description, actualDescription);
            Assert.AreEqual(unitPrice, actualUnitPrice);
            Assert.AreEqual(quantity, actualQuantity);
        }

        /*
         * ToString method
         */

        [TestMethod]
        public void ToString_ReturnStringRepresentation()
        {
            // Arrange
            string description = "Winter Tire";
            decimal unitPrice = 300;
            int quantity = 4;

            VehicleOption vehicleOption = new VehicleOption(description, unitPrice, quantity);

            // Act
            string actual = vehicleOption.ToString();
            string expected = "Winter Tire x 4 @ $300.00";

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
