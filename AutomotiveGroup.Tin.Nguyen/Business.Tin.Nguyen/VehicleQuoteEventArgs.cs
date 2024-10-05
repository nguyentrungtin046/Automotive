/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 17-03-2024
 * Updated:17-03-2024
 */

using System;
using System.Collections.Generic;

namespace Business.Tin.Nguyen
{
    // <summary>
    /// EventArgs class for VehicleOptionAdded event.
    /// </summary>
    public class VehicleOptionAddedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets and sets the optionAdded to the list VehicleOption.
        /// </summary>
        public List<VehicleOption> OptionAdded
        {
            get;
            set;
        }

        public VehicleOptionAddedEventArgs(List<VehicleOption> optionAdded)
        {
            OptionAdded = optionAdded;
        }
    }
}
