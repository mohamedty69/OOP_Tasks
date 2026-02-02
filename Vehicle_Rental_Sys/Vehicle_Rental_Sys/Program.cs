using System;
using Vehicle_Rental_Sys.Classes;
namespace Vehicle_Rental_Sys
 
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create rental agency;
            var agency = new RentalAgency("Prime Car Rentals");

            // Add vehicles to fleet
            var car1 = new Vehicle("V001", "Toyota", "Camry", 2022, 45.00m);
            var car2 = new Vehicle("V002", "Honda", "Accord", 2023, 50.00m);
            var car3 = new Vehicle("V003", "Tesla", "Model 3", 2023, 85.00m);

            agency.addVehicle(car1);
            agency.addVehicle(car2);
            agency.addVehicle(car3);

            // Register customers
            var customer1 = new Customer("C001", "Alice Johnson", "555-0123",
                        "alice@email.com", "DL123456");
            var customer2 = new Customer("C002", "Bob Smith", "555-0456",
                        "bob@email.com", "DL789012");

            agency.addCustomer(customer1);
            agency.addCustomer(customer2);
            agency.displayFleet();

            Console.WriteLine();

            var rental1 = agency.createRental(customer1, car1, 5);
            Console.WriteLine(rental1);

            Console.WriteLine();

            var rental2 = agency.createRental(customer2, car3, 3);
            Console.WriteLine(rental2);

            Console.WriteLine();
            Console.WriteLine("After rentals");
            agency.displayFleet();

            Console.WriteLine();

            Console.WriteLine(agency.completeRental(rental1.rentalId));

            Console.WriteLine();

            var customerRentals = agency.getCustomerRentals("C001");
            Console.WriteLine($"Alice's rental history: {customerRentals.Count} rental(s)");

        }
    }
}
