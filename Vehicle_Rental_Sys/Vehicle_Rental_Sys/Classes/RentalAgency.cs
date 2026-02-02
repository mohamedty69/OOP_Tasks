using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vehicle_Rental_Sys.Classes
{
    public class RentalAgency
    {
        public string agencyName { get; set; }
        public List<Vehicle> vehicles { get; set; }
        public List<Customer> customers { get; set; }
        public List<Rental> rentals { get; set; }
        public RentalAgency(string agencyName)
        {
            this.agencyName = agencyName;
            this.vehicles = new List<Vehicle>();
            this.customers = new List<Customer>();
            this.rentals = new List<Rental>();
        }
        public void addVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }
        public void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public List<Vehicle> getAvailableVehicles()
        {
            var ava = new List<Vehicle>();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.isAvailable == true)
                {
                    ava.Add(vehicle);
                }
            }
            return ava;
        }
        public Rental createRental(Customer customer, Vehicle vehicle, int days)
        {
            var rId = "";
            var C_check = customers.FirstOrDefault(c => c.customerId == customer.customerId);
            if (C_check == null)
            {
                throw new ArgumentNullException("This customer can`t be found");
            }
            var V_check = vehicles.FirstOrDefault(v => v.vehicleId == vehicle.vehicleId);
            if (V_check == null)
            {
                throw new ArgumentNullException("This Vehicle can`t be found");
            }
            else
            {
                vehicle.isAvailable = false;
            }
            if (rentals.Count == 0)
            {
                rId = "R001";
            }
            else
            {
                var lastRental = rentals.Last();
                var lastIdNum = int.Parse(lastRental.rentalId.Substring(1));
                rId = "R" + (lastIdNum + 1).ToString("D3");
            }
            var rental = new Rental(rId,
                customer,
                vehicle,
                DateTime.Now,
                DateTime.Now.AddDays(days));
            rental.isActive = true;

            rentals.Add(rental);

            Console.WriteLine($"Rental Id: {rental.rentalId}\n" +
                $"Customer: {customer.name}\n" +
                $"Vehicle: {vehicle.make} {vehicle.model}\n" +
                $"Start Date: {rental.startDate}\n" +
                $"End Date: {rental.endDate}\n" +
                $"Duration: {rental.getRentalDuration()}\n" +
                $"Total Cost: ${rental.getTotalCost()}");
            return rental;
        }
        public string completeRental(string rental)
        {
            var R_check = rentals.FirstOrDefault(r => r.rentalId == rental);
            if (R_check == null)
            {
                throw new ArgumentNullException("This rental can`t be found");
            }
            else if (!R_check.isActive)
            {
                return "This rental is already completed";
            }
            R_check.isActive = false;
            return $"Rental {R_check.rentalId} completed!\n" +
                $"Vehicle {R_check.vehicle.make} {R_check.vehicle.model} is now available";
        }
        public List<Rental> getActiveRentals()
        {
            var list = new List<Rental>();
            if (rentals.Count == 0) throw new ArgumentException("There isn`t any rentals!");
            foreach (var r in rentals)
            {
                if (r.isActive) { list.Add(r); }
            }
            return list;
        }
        public List<Rental> getCustomerRentals(string cusId)
        {
            var list = new List<Rental>();
            if (rentals.Count == 0) throw new ArgumentException("There isn`t any rentals!");
            foreach (var r in rentals)
            {
                if (r.customer.customerId == cusId)
                {
                    list.Add(r);
                }
            }
            return list;
        }
        public void displayFleet()
        {
            if (vehicles.Count == 0) throw new ArgumentException("There isn`t any rentals!");
            var str = "";
            foreach (var r in vehicles)
            {
                if (r.isAvailable) str = "Available";
                else str = "Unavailable";
                Console.WriteLine($"{r.vehicleId} - {r.year} {r.make} {r.model} - ${r.dailyRate}/day - {str} ");
            }
        }
    }
}