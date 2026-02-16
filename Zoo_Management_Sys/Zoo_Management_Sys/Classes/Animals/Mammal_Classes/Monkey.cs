using System;
using System.Collections.Generic;
using System.Text;
using Zoo_Management_Sys.Classes.Animals;

namespace Zoo_Management_Sys.Classes.Animals.Mammal_Classes
{
    public class Monkey : Animal
    {
        public Monkey(
    string animalID,
    string name,
    string species,
    int age,
    string healthStatus,
    decimal dailyFoodCost,
    decimal tailLength,
    string favoriteFood
) : base(animalID, name, species, age, healthStatus, dailyFoodCost)
        {
            if (tailLength < 0)
                throw new ArgumentException("Task length cannot be negative.");
            TailLength = tailLength;
            FavoriteFood = favoriteFood;
        }
        public decimal TailLength
        { get; set; }
        public string FavoriteFood { get; set; }
        public override string MakeSound()
        {
            return "Ooh ooh ah ah";
        }
        public override string GetHabitat()
        {
            return "Rainforest";
        }
    }
}
