/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 15-01-2024
 * Updated:18-01-2024
 */

namespace Business.Tin.Nguyen
{
    /// <summary>
    /// A class representing a vehicle.
    /// </summary>
    public class Vehicle
    {
        private int year;
        private string model;
        private string manufacturer;
        private PaintColor color;
        private double salePrice;

        /// <summary>
        /// Initialize the state of vehicle when they are created.
        /// </summary>
        /// <param name="year">Represents the year the vehicle was manufactured.</param>
        /// <param name="model">Represents the model of the vehicle.</param>
        /// <param name="manufacturer">Represents the name of the company who manufactured the vehicle.</param>
        /// <param name="color">Represents the paint color of the vehicle.</param>
        /// <param name="salePrice">Represents the sale price of the vehicle.</param>
        public Vehicle(int year, string model, string manufacturer, PaintColor color, double salePrice)
        {
            this.year = year;
            this.model = model;
            this.manufacturer = manufacturer;
            this.color = color;
            this.salePrice = salePrice;
        }

        /// <summary>
        /// Return the year the vehicle was manufactured.
        /// </summary>
        /// <returns>the year the vehicle was manufactured.</returns>
        public int GetYear()
        {
            return year;
        }

        /// <summary>
        /// Return the model of the vehicle.
        /// </summary>
        /// <returns>the model of the vehicle.</returns>
        public string GetModel()
        {
            return model;
        }

        /// <summary>
        /// Return the company who manufactured the vehicle.
        /// </summary>
        /// <returns>the company who manufactured the vehicle.</returns>
        public string GetManufacturer()
        {
        return manufacturer;
        }

        /// <summary>
        /// Accessor of the color of the vehicle.
        /// </summary>
        /// <returns>the color attribute.</returns>
        public PaintColor GetColor()
        {
            return color;
        }

        /// <summary>
        /// Return the price of the vehicle.
        /// </summary>
        /// <returns>the price of the vehicle.</returns>
        public double GetSalePrice()
        {
            return salePrice;
        }

        /// <summary>
        /// Return the string that print things follow format.
        /// </summary>
        /// <returns>returns a strig in the format.</returns>
        public override string ToString()
        {
            return $"{year}, {manufacturer}, {model}, {color}";
        }
    }
}