/*
 * Name: Nguyen Trung Tin
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 15-01-2024
 * Updated:15-01-2024
 */

using System;
using System.Collections.Generic;

namespace Business.Tin.Nguyen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Declare a variable of Quote type.
            Quote quote;

            // 2. Define the variable above to a new Quote instance with a sale price
            //    and tax rate of your choosing.
            quote = new Quote(10000, 0.12);

            // 3. Print the state of the Quote object using accessor methods. 
            //    Format of the output is: 
            //    field: value
            Console.WriteLine($"Sale Price: {quote.GetSalePrice()}");
            Console.WriteLine($"Tax Rate: {quote.GetTaxRate()}");

            // 4. Print the Quote instance created in a previous step.
            Console.WriteLine(quote);

            // 5. Declare and define a new Quote object with the default state.
            Quote newQuote = new Quote();

            // 6. Update the state of the second Quote object with a sale price 
            //    between $10,000 - $15,000 and a tax rate between 4.01% and 4.99% 
            //    (inclusive).
            newQuote.SetSalePrice(12000);
            newQuote.SetTaxRate(0.45);

            // 7. Declare a variable of List type that can store Vehicle objects.
            List<Vehicle> vehicleObjects;

            // 8. Define the variable from the previous step to an empty List object.
            vehicleObjects = new List<Vehicle>();

            // 9. Populate the List with 3 Vehicle objects. Each Vehicle object must 
            //    have unique state.
            vehicleObjects.Add(new Vehicle(2020, "Accord", "Honda", PaintColor.Black, 25000));
            vehicleObjects.Add(new Vehicle(2021, "Camry", "Toyota", PaintColor.Red, 27500));
            vehicleObjects.Add(new Vehicle(2019, "Fusion", "Ford", PaintColor.Blue, 22000));

            // 10. Print out the number of objects in the List, using the List object
            //     reference.
            Console.WriteLine($"Number of Vehicles in the list: {vehicleObjects.Count}");

            // 11. Print out the Vehicle objects from the List.
            foreach (Vehicle i in vehicleObjects)
            {
                Console.WriteLine(i);
            }

            //Using a ReadLine method so the terminal window stays open.
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
