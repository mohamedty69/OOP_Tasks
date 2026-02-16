using System;
using System.Collections.Generic;
using System.Text;
using Zoo_Management_Sys.Classes.Animals;

namespace Zoo_Management_Sys.Classes.Bird_Classes
{
    public class Eagle : Animal
    {
        public Eagle(
    string animalID,
    string name,
    string species,
    int age,
    string healthStatus,
    decimal dailyFoodCost,
    decimal diveSpeed,
    decimal wingSpan
) : base(animalID, name, species, age, healthStatus, dailyFoodCost)
        {
            if (diveSpeed < 0)
                throw new ArgumentException("Dive speed cannot be negative.");
            if (wingSpan < 0)
                throw new ArgumentException("Wing span cannot be negative.");

            DiveSpeed = diveSpeed;
            WingSpan = wingSpan;
        }
        public decimal DiveSpeed { get; set;}
        public decimal WingSpan { get; set; }
        public override string MakeSound()
        {
            return "Screech!";
        }
        public override string GetHabitat()
        {
            return "Mountains";
        }
    }
}
