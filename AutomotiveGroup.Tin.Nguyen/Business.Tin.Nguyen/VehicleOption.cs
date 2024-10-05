/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 06-02-2024
 * Updated:06-02-2024
 */

using System;

namespace Business.Tin.Nguyen
{
    /// <summary>
    /// Represents a vehicleOption.
    /// </summary>
    public class VehicleOption
    {
        /// <summary>
        /// Gets the description of VehicleOption.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the unitPrice of VehicleOption.
        /// </summary>
        public decimal UnitPrice
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the quantity of VehicleOption.
        /// </summary>
        public int Quantity
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an instance of VehicleOption class.
        /// </summary>
        /// <param name="description">Represents the description of the vehicle option.</param>
        /// <param name="unitPrice">Represents the price per unit of the vehicle option.</param>
        /// <param name="quantity">Represents the number of the option ordered.</param>
        /// <exception cref="ArgumentException">
        /// Raises when <paramref name="description"/> contain less than 0 non-whitespace characters.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Raises when <paramref name="quantity"/> and <paramref name="unitPrice"/>
        /// are less than 1.
        /// </exception>
        public VehicleOption(string description, decimal unitPrice, int quantity)
        {
            if (description.Trim().Length < 1)
            {
                throw new ArgumentException("The description must contain non-whitespace characters.", "description");
            }

            if (unitPrice < 0)
            {
                throw new ArgumentOutOfRangeException("unitPrice", "The unitPrice must be 0 or greater.");
            }

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException("quantity", "The quantity must be 0 or greater.");
            }

            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        /// <summary>
        /// Return the string presentation of the VehicleOption.
        /// </summary>
        /// <returns>The string presentation of the VehicleOption</returns>
        public override string ToString()
        {
            return $"{Description} x {Quantity} @ {UnitPrice:C}";
        }
    }
}
