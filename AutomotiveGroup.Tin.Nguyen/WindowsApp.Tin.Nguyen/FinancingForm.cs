/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 08-04-2024
 * Updated: 10-04-2024
 */

using Business.Tin.Nguyen;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsApp.Tin.Nguyen
{   
    /// <summary>
    /// Represents a FinancingForm.
    /// </summary>
    public partial class FinancingForm : ACE.BIT.ADEV.Forms.FinancingForm
    {
        private VehicleQuote vehicleQuote;

        /// <summary>
        /// Initializes a new instance of FinancingForm.
        /// </summary>
        /// <param name="vehicleQuote">The quote of selecting vehicle.</param>
        public FinancingForm(VehicleQuote vehicleQuote)
        {
            InitializeComponent();

            decimal amountDue = vehicleQuote.GetAmountDue();

            this.vehicleQuote = vehicleQuote;
            this.StartPosition = FormStartPosition.CenterParent;
            this.lblQuotedPrice.Text = amountDue.ToString("c");

            List<decimal> loanTerm = new List<decimal>
            {
                3,4,5,6,7
            };

            this.cboLoanTerm.DataSource = loanTerm;
            this.cboLoanTerm.SelectedItem = loanTerm[2];

            this.nudAnnualInterestRate.Minimum = 0;
            this.nudAnnualInterestRate.Maximum = 25;
            this.nudAnnualInterestRate.Increment = 0.25m;
            this.nudAnnualInterestRate.DecimalPlaces = 2;
            this.nudAnnualInterestRate.Value = 3.00m;
            this.nudAnnualInterestRate.ValueChanged += NudAnnualInterestRate_ValueChanged;
            this.cboLoanTerm.SelectedIndexChanged += CboLoanTerm_SelectedIndexChanged;

            this.txtMonthlyPayment.Text = GetMonthlyPayment().ToString("c");
        }

        /// <summary>
        /// Handle the SelectedIndexChanged event of the cboLoanTerm.
        /// </summary>
        private void CboLoanTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtMonthlyPayment.Text = GetMonthlyPayment().ToString("c");
        }

        /// <summary>
        /// Handles the ValueChanged event of the nudAnnualInterestRate.
        /// </summary>
        private void NudAnnualInterestRate_ValueChanged(object sender, EventArgs e)
        {
            this.txtMonthlyPayment.Text = GetMonthlyPayment().ToString("c");
        }

        /// <summary>
        /// Returns the monthly payment of the quote.
        /// </summary>
        /// <returns>The monthly payment of the quote.</returns>
        public decimal GetMonthlyPayment()
        {
            decimal quotePrice = vehicleQuote.GetAmountDue();
            //decimal quotePrice = 6780;
            decimal monthlyInterestRate = (this.nudAnnualInterestRate.Value / 100) / 12;
            decimal numberOfPayment = (decimal)this.cboLoanTerm.SelectedValue * 12;

            return (quotePrice * monthlyInterestRate * (decimal)Math.Pow((1 + (double)monthlyInterestRate), (double)numberOfPayment)) /
                ((decimal)Math.Pow(1 + (double)monthlyInterestRate, (double)numberOfPayment) - 1);
        }
    }
}
