/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 15-01-2024
 * Updated:17-03-2024
 */

using System;

namespace Business.Tin.Nguyen
{
    /// <summary>
    /// Represents an quote.
    /// </summary>
    public abstract class Quote
    {
        private decimal salePrice;

        /// <summary>
        /// Occurs when <see cref="salePrice"/> changes.
        /// </summary>
        public event EventHandler PriceChanged;

        /// <summary>
        /// Gets and sets the salePrice of Quote.
        /// </summary>
        public decimal SalePrice
        {
            get
            {
                return this.salePrice;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The value must be greater than 0.");
                }

                if (this.salePrice != value)
                {
                    this.salePrice = value;

                    OnPriceChanged();
                }
            }
        }

        /// <summary>
        /// Gets the taxRate of Quote.
        /// </summary>
        public decimal TaxRate
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes an instance of the quote.
        /// </summary>
        /// <param name="salePrice">Represents the quoted sale price of an item for sale.</param>
        /// <param name="taxRate">Represents the rate at which tax is charged.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Raises when <paramref name="salePrice"/> is less than or equal to 0,
        /// or when <paramref name="taxRate"/> is less than 0 or bigger than 1.
        /// </exception>
        public Quote(decimal salePrice, decimal taxRate)
        {
            if (salePrice <= 0 )
            {
                throw new ArgumentOutOfRangeException("salePrice", "The salePrice must be greater than 0.");
            }

            if (taxRate < 0 ||  taxRate > 1) 
            {
                throw new ArgumentOutOfRangeException("taxRate", "The taxRate must be within the range of 0 to 1 (inclusive).");
            }

            SalePrice = salePrice;
            TaxRate = taxRate;
        }

        /// <summary>
        /// Returns the sale tax charged for the sale of the quoted item.
        /// </summary>
        /// <returns>The sale tax.</returns>
        public virtual decimal GetSalesTax()
        {
            return SalePrice * TaxRate;
        }

        /// <summary>
        /// Returns the total of the quote.
        /// </summary>
        /// <returns>The total of the quote.</returns>
        public virtual decimal GetTotalOfQuote()
        {
            return GetSalesTax() + SalePrice;
        }

        /// <summary>
        /// Returns the string presentation of Quote.
        /// </summary>
        /// <returns>The string presenting the Quote.</returns>
        public override string ToString()
        {
            return $"Quote: {GetTotalOfQuote():C}";
        }

        /// <summary>
        /// Raises the <see cref="PriceChanged"/> event.
        /// </summary>
        protected virtual void OnPriceChanged()
        {
            if (PriceChanged != null)
            {
                PriceChanged(this, EventArgs.Empty);
            }
        }
    }
}