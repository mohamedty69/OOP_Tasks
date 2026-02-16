
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Zoo_Management_Sys.Classes.Animals;

namespace Zoo_Management_Sys.Classes
{
    public class Zoo
    {
        private const int _count = 0;

        public Zoo(string zooName)
        {
            if (string.IsNullOrWhiteSpace(zooName))
                throw new ArgumentException("Zoo name cannot be null or empty.");
            ZooName = zooName;
        }

        public string ZooName { get; init; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public List<ZooKeeper> ZooKeepers { get; set; } = new List<ZooKeeper>();
        public void AddAnimal(Animal animal)
        {
            if (Animals.Count == 0)
            {
                Animals.Add(animal);
                return;
            }
            else if (Animals.Contains(animal))
            {
                throw new InvalidOperationException("Ainmal is already exist");
            }
            Animals.Add(animal);
        }
        public void RemoveAnimal(Animal animal)
        {
            if (Animals.Count == 0)
            {
                throw new InvalidOperationException("The animals list is empty");
            }
            var checkAnimal = Animals.FirstOrDefault(a => a.AnimalID == animal.AnimalID);
            if (checkAnimal != null)
            {
                Animals.Remove(checkAnimal);
            }
            else throw new InvalidOperationException("Animal not exist");
        }
        public void AssignAnimalToKeeper(Animal animal, ZooKeeper zooKeeper)
        {
            var checkAnimal = zooKeeper.AssignedAnimals.FirstOrDefault(a => a.AnimalID == animal.AnimalID);
            if (checkAnimal == null)
            {
                zooKeeper.AssignedAnimals.Add(animal);
            }
            else throw new InvalidOperationException("Animal is assigned already");
        }
        public IEnumerable<Animal> GetAnimalsByHabitat(string habitat) {
            var animals = Animals.Where(a => a.GetHabitat() == habitat);
            return animals;
        }
        public IEnumerable<Animal> GetAnimalsBySpecies(string species)
        {
            var animals = Animals.Where(a => a.GetHabitat() == species);
            return animals;
        }
        public decimal CalculateTotalWeeklyCost() => Animals.Select(a => a.CalculateWeeklyCost()).Sum();
        public IEnumerable<Animal> DisplayAllAnimals() => Animals.OrderBy(a => a.AnimalID);
        public string GetZooStatistics()
        {
            return $"Total Animals: {Animals.Count}\n" +
                $"Total Zookeepers: {ZooKeepers.Count}\n" +
                $"Habitats Represented: {Animals.Select(a => a.GetHabitat()).Count()}\n" +
                $"Total Weekly Maintenance: ${CalculateTotalWeeklyCost()}\n" +
                $"Average Animal Age: {Animals.Select(a => a.Age).Average()} years";
        }
    }
}
