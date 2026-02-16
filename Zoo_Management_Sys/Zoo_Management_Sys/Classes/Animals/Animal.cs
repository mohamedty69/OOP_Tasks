using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Management_Sys.Classes.Animals
{
    public abstract class Animal
    {
        private const int _daysCount= 7;

        protected Animal(string animalID, string name, string species, int age, string healthStatus, decimal dailyFoodCost)
        {
            if (string.IsNullOrWhiteSpace(animalID))
                throw new ArgumentException("Animal ID cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Animal name cannot be null or empty.");
            if (age < 0)
                throw new ArgumentException("Age cannot be negative.");
            if (dailyFoodCost < 0)
                throw new ArgumentException("Daily food cost cannot be negative.");
            AnimalID = animalID;
            Name = name;
            Species = species;
            Age = age;
            HealthStatus = healthStatus;
            DailyFoodCost = dailyFoodCost;
        }

        public string AnimalID { get; init; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age
        {
            get; set;
        }
        public string HealthStatus { get; set; }
        public decimal DailyFoodCost { get; set;}
        public abstract string MakeSound();
        public abstract string GetHabitat();
        public virtual string GetAnimalInfo()
        {
            return $"ID: {AnimalID}\n" +
                $" Name: {Name}\n" +
                $" Species: {Species}\n" +
                $" Age: {Age}\n" +
                $" Health Status: {HealthStatus}\n" +
                $" Daily Food Cost: {DailyFoodCost:C}";
        }
        public virtual decimal CalculateWeeklyCost()
        {
            return DailyFoodCost * _daysCount;
        }
    }
}
