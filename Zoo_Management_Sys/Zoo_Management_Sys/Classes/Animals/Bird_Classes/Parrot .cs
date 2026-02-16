using System;
using System.Collections.Generic;
using System.Text;
using Zoo_Management_Sys.Classes.Animals;

namespace Zoo_Management_Sys.Classes.Bird_Classes
{
    public class Parrot : Animal
    {
        public Parrot(
            string animalID,
            string name,
            string species,
            int age,
            string healthStatus,
            decimal dailyFoodCost
        ) : base(animalID, name, species, age, healthStatus, dailyFoodCost)
        {
        }
        public List<string> Vocabulary { get; set; } = new List<string>();
        public bool CanTalk { get; set; } = true;
        public override string MakeSound()
        {
            return "Squawk!";
        }
        public override string GetHabitat()
        {
            return "Tropical Forest";
        }   
        public string Speak()
        {
            if (!CanTalk || Vocabulary.Count == 0) throw new InvalidOperationException("This parrot cannot talk or has no vocabulary.");
            var randoNumber = new Random();
            var rnumber = randoNumber.Next(0,Vocabulary.Count - 1);
            return Vocabulary[rnumber];
        }
    }
}
