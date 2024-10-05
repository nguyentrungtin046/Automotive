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
            // 1. Declare a variable that can reference a Vehicle object.
            Vehicle vehicle;

            // 2. Define the variable from the previous step with a new instance of Vehicle.
            vehicle = new Vehicle(2019, "Honda Civic", "Honda", PaintColor.Black, 20000);

            // 3. Declare a variable that can reference a VehicleQuote instance.
            VehicleQuote vehicleQuote;

            // 4. Define the variable from the previous step with a new instance of VehicleQuote.
            //    Specify an argument for tax rate, vehicle and trade-in value.
            vehicleQuote = new VehicleQuote(0.12m, vehicle, 5000);

            // 5. Define a variable to a new instance of the VehicleOption class.
            VehicleOption vehicleOption = new VehicleOption("Yellow Light", 500, 1);

            // 6. Add the VehicleOption created in the previous statement to the options of the
            //    VehicleQuote instance.
            vehicleQuote.AddVehicleOption(vehicleOption);

            // 7. Add two more VehicleOption objects to the VehicleQuote instance. Only use two statements
            //    to accomplish this step.
            vehicleQuote.AddVehicleOption(new VehicleOption("Winter Tire", 300, 4));
            vehicleQuote.AddVehicleOption(new VehicleOption("Leather Seat", 700, 2));

            // 8. Print the quote details to the console.
            //    This step requires defining a sub-procedure method (see below).
            PrintQuoteDetails(vehicleQuote);

            // 9. Remove the first VehicleOption added to the VehicleQuote.
            vehicleQuote.RemoveVehicleOption(vehicleOption);

            // 10. Print the number of VehicleOption objects currently in the quote. Ensure you are
            //     obtaining this information using the VehicleQuote object reference.
            Console.WriteLine($"Number of vehicle options in the quote: {vehicleQuote.GetCopyVehicleOption().Count}");


            //Using a ReadLine method so the terminal window stays open.
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Sub-procedure method prints the details of a VehicleQuote.
        /// </summary>
        /// <param name="vehicleQuote">An argument of VehicleQuote type.</param>
        static void PrintQuoteDetails(VehicleQuote vehicleQuote)
        {
            Console.WriteLine($"Vehicle sale price: {vehicleQuote.SalePrice:C}");
            Console.WriteLine("Option:");
            foreach (VehicleOption option in vehicleQuote.GetCopyVehicleOption())
            {
                Console.WriteLine($"\t{option}");
            }
            Console.WriteLine($"Subtotal: {vehicleQuote.GetSubtotalVehicle():C}");
            Console.WriteLine($"Sales tax: {vehicleQuote.GetSalesTax()}");
            Console.WriteLine($"Total: {vehicleQuote.GetTotalOfQuote():C}");
            Console.WriteLine($"Trade-in value: -{vehicleQuote.TradeInValue}");
            Console.WriteLine($"Amount due: {vehicleQuote.GetAmountDue():C}");
        }
    }
}
