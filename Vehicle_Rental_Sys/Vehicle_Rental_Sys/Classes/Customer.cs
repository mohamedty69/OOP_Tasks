using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Rental_Sys.Classes
{
    public class Customer
    {
        public string customerId { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string driversLicenseNumber { get; set; }
        public Customer(string customerId,string name,string phone, string email,string driversLicenseNumber)
        {
            this.customerId = customerId;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.driversLicenseNumber = driversLicenseNumber;
        }
        public string customerInfo()
        { 
            return $"Customer Id: {customerId}\n"+
                $"Name: {name}\n"+
                $"Phone: {phone}\n"+
                $"Email: {email}\n"+
                $"Driver License Number: {driversLicenseNumber}";
        }
    }
}
