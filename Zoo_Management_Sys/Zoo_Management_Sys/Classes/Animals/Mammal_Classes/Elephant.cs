using System;
using Zoo_Management_Sys.Classes.Animals;

namespace Zoo_Management_Sys.Classes.Animals.Mammal_Classes
{
    public class Elephant : Animal
    {
        public Elephant(
            string animalID,
            string name,
            string species,
            int age,
            string healthStatus,
            decimal dailyFoodCost,
            decimal taskLength,
            decimal weight
        ) : base(animalID, name, species, age, healthStatus, dailyFoodCost)
        {
            if (taskLength < 0)
                throw new ArgumentException("Task length cannot be negative.");
            if (weight < 0)
                throw new ArgumentException("Weight cannot be negative.");

            TaskLength = taskLength;
            Weight = weight;
        }

        public decimal TaskLength { get; set; }
        public decimal Weight { get; set; }

        public override string MakeSound()
        {
            return "Trumpet!";
        }
        public override string GetHabitat()
        {
            return "Grassland";
        }
    }
}
