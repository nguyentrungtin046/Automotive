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
    /// A class representing a quote.
    /// </summary>
    public class Quote
    {
        private double salePrice;
        private double taxRate;

        /// <summary>
        /// Initialize an instance of the quote.
        /// </summary>
        /// <param name="salePrice">Represents the quoted sale price of an item for sale.</param>
        /// <param name="taxRate">Represents the rate at which tax is charged.</param>
        public Quote(double salePrice, double taxRate)
        {
            this.salePrice = salePrice;
            this.taxRate = taxRate;
        }

        /// <summary>
        /// Initialize an instance of the quote with 0 at the sale price an tax.
        /// </summary>
        public Quote(): this (0, 0)
        {

        }

        /// <summary>
        /// Accessor of the salePrice.
        /// </summary>
        /// <returns>the value of salePrice attribute.</returns>
        public double GetSalePrice()
        { 
            return salePrice; 
        }

        /// <summary>
        /// Mutator of the salePrice.
        /// </summary>
        /// <param name="salePrice">Change the value of the salePrice attribute.</param>
        public void SetSalePrice(double salePrice)
        {
            this.salePrice = salePrice;
        }

        /// <summary>
        /// Accessor of the taxRate.
        /// </summary>
        /// <returns>The value of the taxRate attribute.</returns>
        public double GetTaxRate() 
        {
            return taxRate;
        }

        /// <summary>
        /// Mutator if the taxRate.
        /// </summary>
        /// <param name="taxRate">Change the value of the taxRate attribute.</param>
        public void SetTaxRate(double taxRate)
        {
            this.taxRate = taxRate;
        }

        /// <summary>
        /// A method that returns the sale tax charged for the sale of the quoted item.
        /// </summary>
        /// <returns>the sale tax.</returns>
        public double SalesTax()
        {
            double salesTax = this.salePrice * this.taxRate;
            return salesTax;
        }

        /// <summary>
        /// A method that returns the total of the quote.
        /// </summary>
        /// <returns>The total of the quote.</returns>
        public double TotalOfQuote()
        {
            double saleTax = SalesTax();
            double totalOfQuote = salePrice + saleTax;
            return totalOfQuote;
        }

        /// <summary>
        /// Return the string presentation of Quote.
        /// </summary>
        /// <returns>The string presenting the Quote.</returns>
        public override string ToString()
        {
            return $"Quote: {TotalOfQuote():C}";
        }
    }
}