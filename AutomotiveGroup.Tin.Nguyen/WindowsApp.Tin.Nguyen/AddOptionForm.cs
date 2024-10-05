/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 08-04-2024
 * Updated: 10-04-2024
 */

using Business.Tin.Nguyen;
using System;
using System.Windows.Forms;

namespace WindowsApp.Tin.Nguyen
{
    /// <summary>
    /// Represents an AddOptionForm.
    /// </summary>
    public partial class AddOptionForm : ACE.BIT.ADEV.Forms.AddOptionForm
    {
        private VehicleOption newVehicleOption;

        /// <summary>
        /// Gets the NewVehicleOption.
        /// </summary>
        public VehicleOption NewVehicleOption
        {
            get
            {
                return newVehicleOption;
            }
        }

        /// <summary>
        /// Initializes a new instance of AddOptionForm.
        /// </summary>
        public AddOptionForm()
        {
            this.StartPosition = FormStartPosition.CenterParent;

            this.nudQuantity.Minimum = 1;
            this.nudQuantity.Maximum = 100;
            this.nudQuantity.ReadOnly = true;

            this.errorProvider.SetIconPadding(this.txtDescription, 3);
            this.errorProvider.SetIconPadding(this.txtUnitPrice, 3);
            this.errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            newVehicleOption = null;

            btnAdd.Click += BtnAdd_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        /// <summary>
        /// Handles the Click event of btnCancel.
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of btnAdd.
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string description = this.txtDescription.Text;
            string unitPrice = this.txtUnitPrice.Text;
            int quantity = (int)this.nudQuantity.Value;
            decimal unitPriceParse = 0;
            bool isValidInput = true;

            // Ensure all error icons are not visible.
            this.errorProvider.SetError(this.txtDescription, string.Empty);
            this.errorProvider.SetError(this.txtUnitPrice, string.Empty);

            try
            {
                unitPriceParse = decimal.Parse(unitPrice);
                if (unitPriceParse < 0)
                {
                    this.errorProvider.SetError(this.txtUnitPrice,
                        "The unit price must be equal or greater than 0.");
                    isValidInput = false;
                }
            }
            catch
            {
                this.errorProvider.SetError(this.txtUnitPrice, "The unit price must be a numeric.");
                isValidInput = false;
            }

            if (description.Length < 1)
            {
                this.errorProvider.SetError(this.txtDescription,
                    "The input should contain at least a non-whitespace character.");
                isValidInput = false;
            }
            
            if (isValidInput)
            {
                this.newVehicleOption = new VehicleOption(description, unitPriceParse, quantity);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
