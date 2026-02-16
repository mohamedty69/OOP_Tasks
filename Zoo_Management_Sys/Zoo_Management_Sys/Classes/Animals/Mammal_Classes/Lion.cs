using System;
using System.Collections.Generic;
using System.Text;
using Zoo_Management_Sys.Classes.Animals;

namespace Zoo_Management_Sys.Classes.Animals.Mammal_Classes
{
    public class Lion : Animal
    {
        public Lion(
            string animalID,
            string name,
            string species,
            int age,
            string healthStatus,
            decimal dailyFoodCost,
            decimal prideSize,
            string mammalColor
        ) : base(animalID, name, species, age, healthStatus, dailyFoodCost)
        {
            if (prideSize < 0)
                throw new ArgumentException("Pride size cannot be negative.");
            PrideSize = prideSize;
            MammalColor = mammalColor;
        }
        public decimal PrideSize {get; set; }
        public string MammalColor { get; set; }
        public override string MakeSound()
        {
            return "Roar!";
        }
        public override string GetHabitat()
        {
            return "Savanna";
        }   
    }
}
