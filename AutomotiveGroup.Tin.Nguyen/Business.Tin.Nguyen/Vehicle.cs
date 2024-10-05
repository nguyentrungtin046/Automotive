/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 15-01-2024
 * Updated:06-02-2024
 */

using System;

namespace Business.Tin.Nguyen
{
    /// <summary>
    /// Represents a vehicle.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Gets the Year of the Vehicle.
        /// </summary>
        public int Year
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Model of the Vehicle.
        /// </summary>
        public string Model
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Gets the Manufacturer of the Vehicle.
        /// </summary>
        public string Manufacturer
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Gets the Color of the Vehicle.
        /// </summary>
        public PaintColor Color
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Gets the SalePrice of the Vehicle.
        /// </summary>
        public decimal SalePrice
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the Vehicle class.
        /// </summary>
        /// <param name="year">Represents the year the vehicle was manufactured.</param>
        /// <param name="model">Represents the model of the vehicle.</param>
        /// <param name="manufacturer">Represents the name of the company who manufactured the vehicle.</param>
        /// <param name="color">Represents the paint color of the vehicle.</param>
        /// <param name="salePrice">Represents the sale price of the vehicle.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Raise when <paramref name="year"/> smaller than 1950 or 2024
        /// or when <paramref name="salePrice"/> is less than 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Raise when <paramref name="manufacturer"/> or <paramref name="model"/>
        /// contain less than 1 non-whitespace characters.
        /// </exception>
        public Vehicle(int year, string model, string manufacturer, PaintColor color, decimal salePrice)
        {   
            if (year < 1950 || year > 2025)
            {
                throw new ArgumentOutOfRangeException("year", "The year must be in the range of 1950 to 2025.");
            }

            if (manufacturer.Trim().Length < 1)
            {
                throw new ArgumentException("The manufacturer must contain non-whitespace characters.", "manufacturer");
            }

            if (model.Trim().Length < 1) 
            {
                throw new ArgumentException("The model must contain non-whitespace characters.", "model");
            }

            if (salePrice < 0)
            {
                throw new ArgumentOutOfRangeException("salePrice", "The salePrice must be 0 or greater.");
            }

            Year = year;
            Model = model;
            Manufacturer = manufacturer;
            Color = color;
            SalePrice = salePrice;
        }

        /// <summary>
        /// Returns the string that print things follow format.
        /// </summary>
        /// <returns>The a string in the format.</returns>
        public override string ToString()
        {
            return $"{Year}, {Manufacturer}, {Model}, {Color}";
        }
    }
}