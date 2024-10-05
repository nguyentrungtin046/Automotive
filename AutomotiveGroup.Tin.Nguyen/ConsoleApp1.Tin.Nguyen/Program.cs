/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 15-01-2024
 * Updated:08-02-2024
 */

using System;
using System.Collections.Generic;

namespace Business.Tin.Nguyen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Declare and define a variable that references a VehicleQuote object.
            VehicleQuote vehicleQuote = new VehicleQuote(0.07m, new Vehicle(2024, "Ford", "Hybrid", PaintColor.Blue, 29000));

            // 2. Define a method in this class that handles the event that occurs when the sale price changes.
            //    The handler method will print: "The sale price changed to {sale-price}."
            //    Subscribe to the event below using the handler method you just defined.            
            vehicleQuote.PriceChanged += Quote_SalePriceChange;

            // 3. Define a method in this class that handles the event that occurs when an option is added to the quote.
            //    The handler method will print: "The following option was added to the quote:\n{vehicle-option}" 
            //    Subscribe to the event below using the handler method you just defined.
            vehicleQuote.VehicleOptionAdded += VehicleQuote_VehicleOptionAdded;

            // 4. Define a method in this class that handles the event that occurs when trade-in value has been changed.
            //    The handler method will print "The trade-in value has been changed."
            //    Subscribe to the event below using the handler method you just defined.            
            vehicleQuote.TradeInValueChanged += VehicleQuote_TradeInValueChanged;

            // 5. Declare and define a variable to reference a new instance of the VehicleOption class.
            VehicleOption option = new VehicleOption("winter tire", 250, 4);

            // 6. Add the VehicleOption created in the previous statement to the options of the
            //    VehicleQuote instance.
            vehicleQuote.AddVehicleOption(option);

            // 7. Add two more VehicleOption objects to the VehicleQuote instance. Only use two statements
            //    to accomplish this step.
            vehicleQuote.AddVehicleOption(new VehicleOption("Leather Seats", 1000, 1));
            vehicleQuote.AddVehicleOption(new VehicleOption("Sunroof", 800, 1));

            // 8. Change the sale price of the VehicleQuote to a different value than its current state.
            vehicleQuote.SalePrice = 30000;

            // 9. Add another VehicleOption to the VehicleQuote.
            vehicleQuote.AddVehicleOption(new VehicleOption("GPS Navigation", 500, 1));

            // 10. Change the trade-in value of the VehicleQuote to a different value than its current state.
            vehicleQuote.TradeInValue = 2000;

            // 11. Repeat the previous statement.
            vehicleQuote.TradeInValue = 2000;

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Handles the SalePriceChanged event of a Quote.
        /// </summary>
        static void Quote_SalePriceChange(object sender, EventArgs e)
        {
            Quote quote = (Quote)sender;

            Console.WriteLine($"The sale price changed to {quote.SalePrice}");
        }

        /// <summary>
        /// Handles the VehicleOptionAdded event of a VehicleQuote.
        /// </summary>
        static void VehicleQuote_VehicleOptionAdded(object sender, VehicleOptionAddedEventArgs e)
        {
            VehicleOption newOption = e.OptionAdded[e.OptionAdded.Count - 1];           
            Console.WriteLine($"The following option was added to the quote:\n" +
                $"{newOption}");          
        }

        /// <summary>
        /// Handles the TraInValueChanged event of a VehicleQuote.
        /// </summary>
        static void VehicleQuote_TradeInValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The trade-in value has been changed.");
        }
    }
}
