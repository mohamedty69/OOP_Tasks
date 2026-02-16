using System;
using System.Collections.Generic;
using System.Text;
using Zoo_Management_Sys.Classes.Animals;

namespace Zoo_Management_Sys.Classes.Reptile_Classes
{
    public class Crocodile : Animal
    {
        public Crocodile(
            string animalID,
            string name,
            string species,
            int age,
            string healthStatus,
            decimal dailyFoodCost,
            decimal jawstrength,
            decimal weight
        ) : base(animalID, name, species, age, healthStatus, dailyFoodCost)
        {
            if (jawstrength < 0)
                throw new ArgumentException("Jaw strength cannot be negative.");
            if (weight < 0)
                throw new ArgumentException("Weight cannot be negative.");
            Jawstrength = jawstrength;
            Weight = weight;
        }
        public decimal Jawstrength { get; set; }
        public decimal Weight { get; set; }
        public override string MakeSound()
        {
            return "Grow!";
        }
        public override string GetHabitat()
        {
            return "Swamp";
        }
    }
}
