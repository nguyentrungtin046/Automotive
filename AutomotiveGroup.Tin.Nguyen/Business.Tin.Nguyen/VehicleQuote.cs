﻿/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 07-02-2024
 * Updated:07-02-2024
 */

using System;
using System.Collections.Generic;
using System.Configuration;

namespace Business.Tin.Nguyen
{
    /// <summary>
    /// Represents the VehicleQuote as Quote.
    /// </summary>
    public class VehicleQuote : Quote
    {
        private decimal tradeInValue;
        private List<VehicleOption> options;
        private Vehicle vehicle;

        /// <summary>
        /// Occurs when the <see cref="TradeInValue"/> changes.
        /// </summary>
        public event EventHandler TradeInValueChanged;

        /// <summary>
        /// Occurs when the <see cref="VehicleOption"/> object is added to the VehicleQuote object's options attribute.
        /// </summary>
        public event EventHandler<VehicleOptionAddedEventArgs> VehicleOptionAdded;

        /// <summary>
        /// Occurs when the <see cref="VehicleOption"/> object is removed to the VehicleQuote object's options attribute.
        /// </summary>
        public event EventHandler VehicleOptionRemoved;

        /// <summary>
        /// Gets and sets the traInValue of VehicleQuote.
        /// </summary>
        public decimal TradeInValue
        {
            get
            {
                return this.tradeInValue;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be 0 or greater.");
                }

                if (value != this.tradeInValue)
                {
                    this.tradeInValue = value;

                    OnTradeInValueChanged();
                }
            }
        }

        /// <summary>
        /// Gets and sets the vehicle of VehicleQuote.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Raises when the value is null.
        /// </exception>
        public Vehicle Vehicle
        {
            get
            {
                return this.vehicle;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "The value must be a reference to a Vehicle.");
                }
                this.vehicle = value;
                SalePrice = vehicle.SalePrice;
            }
        }

        /// <summary>
        /// Initializes an instance of VehicleQuote class.
        /// </summary>
        /// <param name="taxRate">Represents the rate at which tax is charged.</param>
        /// <param name="vehicle">Represents the vehicle the quote is being prepared for.</param>
        /// <param name="tradeInValue">the amount offered by the quoting company 
        /// for a customer's existing vehicle to offset the cost of a new vehicle.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Raises when <paramref name="tradeInValue"/> less than 0,
        /// or when <paramref name="taxRate"/> is less than 0 or bigger than 1.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// Raises when <paramref name="vehicle"/> is null.
        /// </exception>
        public VehicleQuote(decimal taxRate, Vehicle vehicle, decimal tradeInValue = 0) : base(vehicle.SalePrice, taxRate)
        {      
            if (tradeInValue < 0)
            {
                throw new ArgumentOutOfRangeException("tradeInValue", "The tradeInValue must be 0 or greater.");
            }

            options = new List<VehicleOption>();
            this.vehicle = vehicle;
            this.tradeInValue = tradeInValue;
        }

        /// <summary>
        /// Adds a specified VehicleOption to the options of the VehicleQuote.
        /// </summary>
        /// <param name="vehicleOption">The vehicleOption to add.</param>
        /// <exception cref="ArgumentNullException">
        /// Raises when vehicleOption is null.
        /// </exception>
        public void AddVehicleOption(VehicleOption vehicleOption)
        {
            if (vehicleOption == null)
            {
                throw new ArgumentNullException("vehicleOption", "The vehicleOption must reference an object.");
            }

            options.Add(vehicleOption);

            OnVehicleOptionAdded();
        }
            
        /// <summary>
        /// Removes a specified VehicleOption from the options of the VehicleQuote.
        /// </summary>
        /// <param name="vehicleOption">The vehicleOption to remove.</param>
        public void RemoveVehicleOption(VehicleOption vehicleOption)
        {
            options.Remove(vehicleOption);

            OnVehicleOptionRemoved();
        }

        /// <summary>
        /// Returns a copy of the options of the VehicleQuote.
        /// </summary>
        /// <returns>A copy of the options of the VehicleQuote.</returns>
        public List<VehicleOption> GetCopyVehicleOption()
        {
            return new List<VehicleOption>(options);
        }

        /// <summary>
        /// Returns the sum of the VehicleQuote options.
        /// </summary>
        /// <returns>The sum of the VehicleQuote options.</returns>
        public decimal GetSumVehicleOption()
        {
            decimal total = 0;
            foreach (VehicleOption option in options)
            {
                total += option.UnitPrice * option.Quantity;
            }
            return total;
        }

        /// <summary>
        /// Returns the subtotal of the VehicleQuote.
        /// </summary>
        /// <returns>The subtotal of the VehicleQuote.</returns>
        public decimal GetSubtotalVehicle()
        {
            return vehicle.SalePrice + GetSumVehicleOption();
        }

        /// <summary>
        /// Returns the VehicleQuote sale tax.
        /// </summary>
        /// <returns>The VehicleQuote sale tax..</returns>
        public override decimal GetSalesTax()
        {
            return GetSubtotalVehicle() * TaxRate;
        }

        /// <summary>
        /// Returns the total of the VehicleQuote.
        /// </summary>
        /// <returns>The total of the VehicleQuote.</returns>
        public override decimal GetTotalOfQuote()
        {
            decimal sum = GetSubtotalVehicle() + GetSalesTax();
            return Math.Round(sum, 2);
        }

        /// <summary>
        /// Returns the amount due for the vehicle being purchased.
        /// </summary>
        /// <returns>The amount due for the vehicle being purchased.</returns>
        public decimal GetAmountDue()
        {
            return GetTotalOfQuote() - TradeInValue;
        }

        /// <summary>
        /// Returns the string presentation of the VehicleQuote.
        /// </summary>
        /// <returns>The string presentation of the VehicleQuote.</returns>
        public override string ToString()
        {
            return $"VehicleQuote: {GetAmountDue():C}";
        }

        /// <summary>
        /// Raises the <see cref=">TradeInValueChanged"/> event.
        /// </summary>
        protected virtual void OnTradeInValueChanged()
        {
            if (TradeInValueChanged != null)
            {
                TradeInValueChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raises the <see cref="VehicleOptionAdded"/> event.
        /// </summary>
        protected virtual void OnVehicleOptionAdded()
        {
            if (VehicleOptionAdded != null)
            {
                VehicleOptionAdded(this, new VehicleOptionAddedEventArgs(options));
            }
        }

        /// <summary>
        /// Raises the <see cref="VehicleOptionRemoved"/> event.
        /// </summary>
        protected virtual void OnVehicleOptionRemoved()
        {
            if (VehicleOptionRemoved != null)
            {
                VehicleOptionRemoved(this, EventArgs.Empty);
            }
        }
    }
}
