using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Rental_Sys.Classes
{
    public class Vehicle
    {
        public string vehicleId { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public decimal dailyRate { get; set; }

        public bool isAvailable = true;
        public Vehicle(string vehicleId, string make, string model, int year, decimal dailyRate)
        {
            this.vehicleId = vehicleId;
            this.make = make;
            this.model = model;
            this.year = year;
            this.dailyRate = dailyRate;
        }
        public string getVehicleInfo() {
            return $"Vehicle ID: {vehicleId}\n" +
                $" Make: {make}\n" +
                $" Model: {model}\n" +
                $" Year: {year}\n"+
                $" Daily Rate: {dailyRate}\n" +
                $" Available: {isAvailable}\n";
        }
        public void rent()
        {
            if (isAvailable)
            {
                isAvailable = false;
            }
            else
            {
                throw new InvalidOperationException("Vehicle is already rented.");
            }
        }
        public void returnVehicle()
        {
            if (isAvailable)
            {
                isAvailable = true;
            }
        }
        public decimal calculateRentalCost(int days)
        {
            return dailyRate * days;
        }
    }
}
