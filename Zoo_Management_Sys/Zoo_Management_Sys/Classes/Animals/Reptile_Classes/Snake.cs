using System;
using System.Collections.Generic;
using System.Text;
using Zoo_Management_Sys.Classes.Animals;

namespace Zoo_Management_Sys.Classes.Reptile_Classes
{
    public class Snake : Animal
    {
        public Snake(
            string animalID,
            string name,
            string species,
            int age,
            string healthStatus,
            decimal dailyFoodCost,
            bool isVenomous,
            decimal length
        ) : base(animalID, name, species, age, healthStatus, dailyFoodCost)
        {
            IsVenomous = isVenomous;
            if (length < 0)
                throw new ArgumentException("Length cannot be negative.");
            Length = length;
        }
        public bool IsVenomous { get; set; } = false;
        public decimal Length { get; set; }
        public override string MakeSound()
        {
            return "Hiss!";
        }
        public override string GetHabitat()
        {
            return "Desert";
        }
    }
}
