/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 08-04-2024
 * Updated: 10-04-2024
 */

using System;
using System.Collections.Generic;
using Business.Tin.Nguyen;
using System.Windows.Forms;

namespace WindowsApp.Tin.Nguyen
{
    /// <summary>
    /// Represents a QuoteForm.
    /// </summary>
    public class QuoteForm : ACE.BIT.ADEV.Forms.QuoteForm
    {
        private VehicleQuote vehicleQuote;


        /// <summary>
        /// Gets and sets the VehicleQuote.
        /// </summary>
        public VehicleQuote VehicleQuote
        {
            get;
            set;
        }

        /// <summary>
        /// Gets and sets TaxRate.
        /// </summary>
        public decimal TaxRate
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the QuoteForm class.
        /// </summary>
        public QuoteForm() 
        {
            InitializeForm();
            CreateVehicleList();
            this.mnuNew.Click += MnuNew_Click;
            this.mnuExit.Click += MnuExit_Click;
            this.mnuAddOption.Click += MnuAddOption_Click;
            this.mnuRemoveOption.Click += MnuRemoveOption_Click;
            this.mnuFinancing.Click += MnuFinancing_Click;
            this.mnuAbout.Click += MnuAbout_Click;

            this.cboVehicle.SelectedValueChanged += CboVehicle_SelectedValueChanged;
            this.nudTradeInValue.ValueChanged += NudTradeInValue_ValueChanged;

            this.btnAddOption.Click += BtnAddOption_Click;
            this.btnRemoveOption.Click += BtnRemoveOption_Click;
        }

        /// <summary>
        /// Handles the Click event of btnRemoveOption.
        /// </summary>
        private void BtnRemoveOption_Click(object sender, EventArgs e)
        {
            this.MnuRemoveOption_Click(sender, e);
        }

        /// <summary>
        /// Handles the Click event of btnAddOption.
        /// </summary>
        private void BtnAddOption_Click(object sender, EventArgs e)
        {
            this.MnuAddOption_Click(sender, e);
        }

        /// <summary>
        /// Handles the ValueChanged event of nudTradeInValue.
        /// </summary>
        private void NudTradeInValue_ValueChanged(object sender, EventArgs e)
        {
            UpdateTxtBoxes();
        }

        /// <summary>
        /// Handles the SelectedValueChanged event of cboVehicle.
        /// </summary>
        private void CboVehicle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboVehicle.SelectedIndex == -1)
            {
                InitializeForm();
            }
            else
            {
                this.mnuAddOption.Enabled = true;
                this.mnuRemoveOption.Enabled = true;
                this.mnuFinancing.Enabled = true;

                this.btnAddOption.Enabled = true;
                this.btnRemoveOption.Enabled = true;

                this.nudTradeInValue.Enabled = true;

                Vehicle selectedVehicle = (Vehicle)this.cboVehicle.SelectedItem;

                if (this.VehicleQuote == null)
                {
                    vehicleQuote = new VehicleQuote(TaxRate, selectedVehicle);
                }
                else
                {
                    vehicleQuote.Vehicle = selectedVehicle;
                }

                this.nudTradeInValue.Maximum = selectedVehicle.SalePrice;

                UpdateTxtBoxes();
            }
        }

        /// <summary>
        /// Handles the Click event of the mnuAbout.
        /// </summary>
        private void MnuAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the mnuRemoveOption.
        /// </summary>
        private void MnuRemoveOption_Click(object sender, EventArgs e)
        {
            if (lstVehicleOptions.SelectedIndex != -1)
            {
                VehicleOption selectedOption = (VehicleOption)lstVehicleOptions.SelectedItem;
                vehicleQuote.RemoveVehicleOption(selectedOption);
                List<VehicleOption> optionsList = vehicleQuote.GetCopyVehicleOption();

                this.lstVehicleOptions.DataSource = optionsList;

                UpdateTxtBoxes();
            }
        }

        /// <summary>
        /// Handles the Click event of the mnuFinancing.
        /// </summary>
        private void MnuFinancing_Click(object sender, EventArgs e)
        {
            new FinancingForm(vehicleQuote).ShowDialog();          

        }

        /// <summary>
        /// Handles the Click event of the mnuAddOption.
        /// </summary>
        private void MnuAddOption_Click(object sender, EventArgs e)
        {
            AddOptionForm addOptionForm = new AddOptionForm();
            DialogResult result = addOptionForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                VehicleOption vehicleOption = addOptionForm.NewVehicleOption;
                vehicleQuote.AddVehicleOption(vehicleOption);
                List<VehicleOption> optionsList = vehicleQuote.GetCopyVehicleOption();     
                this.lstVehicleOptions.DataSource = optionsList;
                this.lstVehicleOptions.ClearSelected();
                UpdateTxtBoxes() ;
            }
        }

        /// <summary>
        /// Handles the Click event of the mnuExit.
        /// </summary>
        private void MnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the mnuNew.
        /// </summary>
        private void MnuNew_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("The current quote will be lost. Continues?",
                "New Quote", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                InitializeForm();
                this.cboVehicle.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Initializes initial form of the QuoteForm.
        /// </summary>
        private void InitializeForm()
        {        
            this.TaxRate = 0.12m;

            this.Text = "VehicleQuote - Tin Nguyen";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.lblTaxRate.Text = $"Tax ({TaxRate:P2})";

            this.nudTradeInValue.Minimum = 0;
            this.nudTradeInValue.Maximum = 1000000;
            this.nudTradeInValue.DecimalPlaces = 2;
            this.nudTradeInValue.Increment = 500;
            this.nudTradeInValue.Value = 0;
            this.nudTradeInValue.ThousandsSeparator = true;
            this.nudTradeInValue.Enabled = false;

            this.mnuAddOption.Enabled = false;
            this.mnuRemoveOption.Enabled = false;
            this.mnuFinancing.Enabled = false;

            this.btnAddOption.Enabled = false;
            this.btnRemoveOption.Enabled = false;

            this.txtSalePrice.Text = string.Empty;
            this.txtTotalOptions.Text = string.Empty;
            this.txtSubtotal.Text = string.Empty;
            this.txtTax.Text = string.Empty;
            this.txtTotal.Text = string.Empty;
            this.txtAmountDue.Text = string.Empty;
            this.lstVehicleOptions.DataSource = null;

            this.vehicleQuote = null;
        }

        /// <summary>
        /// Updates information in the form.
        /// </summary>
        private void UpdateTxtBoxes()
        {
            vehicleQuote.TradeInValue = nudTradeInValue.Value;

            this.txtSalePrice.Text = vehicleQuote.SalePrice.ToString("c");

            decimal totalOption = vehicleQuote.GetSumVehicleOption();
            this.txtTotalOptions.Text = totalOption.ToString();

            decimal subtotal = vehicleQuote.GetSubtotalVehicle();
            this.txtSubtotal.Text= subtotal.ToString("c");

            decimal tax = vehicleQuote.GetSalesTax();
            this.txtTax.Text = tax.ToString();

            decimal total = vehicleQuote.GetTotalOfQuote();
            this.txtTotal.Text = total.ToString("c");

            decimal amountDue = vehicleQuote.GetAmountDue();
            this.txtAmountDue.Text= amountDue.ToString("c");
        }

        /// <summary>
        /// Initializes a VehicleList.
        /// </summary>
        public void CreateVehicleList()
        {
            List<Vehicle> vehicle = new List<Vehicle>
            {
                new Vehicle(2022, "Camry LE", "Toyota", PaintColor.Black, 25000),
                new Vehicle(2023, "Accord LX", "Honda", PaintColor.White, 28500),
                new Vehicle(2021, "Mustang GT", "Ford", PaintColor.Red, 40000),
                new Vehicle(2020, "Malibu LS", "Chevrolet", PaintColor.Blue, 22500),
                new Vehicle(2022, "330i", "BMW", PaintColor.Black, 45000),
                new Vehicle(2023, "E350", "Mercedes-Benz", PaintColor.Grey, 55000),
                new Vehicle(2021, "A4 Premium", "Audi", PaintColor.White, 35000),
                new Vehicle(2022, "Model 3 Standard Range Plus", "Tesla", PaintColor.White, 45000),
                new Vehicle(2020, "Altima SV", "Nissan", PaintColor.Black, 24000),
                new Vehicle(2023, "Sonata SEL", "Hyundai", PaintColor.Grey, 27500)
            };

            this.cboVehicle.DataSource = vehicle;
            this.cboVehicle.SelectedIndex = -1;
            this.cboVehicle.Focus();
        }
    }
}
