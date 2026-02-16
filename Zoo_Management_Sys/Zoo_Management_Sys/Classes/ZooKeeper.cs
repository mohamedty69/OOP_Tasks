using System;
using System.Collections.Generic;
using System.Text;
using Zoo_Management_Sys.Classes.Animals;

namespace Zoo_Management_Sys.Classes
{
    public class ZooKeeper
    {
        public ZooKeeper(string employeeId, string name, string specialization)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
                throw new ArgumentException("Employee ID cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.");
            EmployeeId = employeeId;
            Name = name;
            Specialization = specialization;
        }

        public string EmployeeId { get; init; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<Animal> AssignedAnimals { get; set; } = new List<Animal>();
        public string FeedAnimal(Animal animal)
        {
            return $"{Name} fed {animal.Name} ({animal.Species})";
        }
        public string CheckAnimalHealth(Animal animal)
        {
            return $"{Name} checked health of {animal.Name} ({animal.Species}) - Status: {animal.HealthStatus}";
        }
        public int GetWorkLoad()
        {
            if (AssignedAnimals.Count > 0)
            {
                return AssignedAnimals.Count ;
            }
            else
            {
                throw new InvalidOperationException("There is no assigned animals to this keeper");
            }
        }
    }
}
