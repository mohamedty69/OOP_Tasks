using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Rental_Sys.Classes
{
    public class Rental
    {
        public string rentalId {  get; set; }
        public Customer customer { get; set; }
        public Vehicle vehicle { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isActive = false;
        public Rental(string rentalId,Customer customer, Vehicle vehicle,DateTime startDate, DateTime endDate)
        {
            this.rentalId = rentalId;
            this.customer = customer;
            this.vehicle = vehicle;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public int getRentalDuration()
        {
            var dur = endDate.Day - startDate.Day;
            return dur;
        }
        public decimal getTotalCost()
        {
            return vehicle.dailyRate * getRentalDuration();
        }
        public void completeRental()
        {
            isActive = true;
        }
        public string getRentalInfo()
        {
            return $"Rental Id: {rentalId}\n" +
                $"Customer Info:\n{customer.customerInfo()}\n" +
                $"Vehicle Info:\n{vehicle.getVehicleInfo()}\n" +
                $"Start Date:{startDate}\n" +
                $"End Date: {endDate}";
        }
        
    }
}
