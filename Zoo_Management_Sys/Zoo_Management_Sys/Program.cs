using Zoo_Management_Sys.Classes;
using Zoo_Management_Sys.Classes.Animals;
using Zoo_Management_Sys.Classes.Animals.Mammal_Classes;
using Zoo_Management_Sys.Classes.Bird_Classes;
using Zoo_Management_Sys.Classes.Reptile_Classes;

namespace Zoo_Management_Sys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create zoo
            var zoo = new Zoo("Safari World");

            // Create animals
            var lion = new Lion("A001", "Simba", "African Lion", 5, "Healthy", 50.00m, 3m, "Golden");
            var elephant = new Elephant("A002", "Dumbo", "African Elephant", 15, "Healthy", 80.00m, 2.5m, 5000);
            var parrot = new Parrot("A003", "Polly", "Macaw", 8, "Healthy", 10.00m);
            parrot.Vocabulary.Add("Hello");
            parrot.Vocabulary.Add("Goodbye");
            parrot.Vocabulary.Add("Pretty bird");
            var snake = new Snake("A004", "Kaa", "Python", 10, "Healthy", 15.00m, true, 4.5m);
            var eagle = new Eagle("A005", "Freedom", "Bald Eagle", 6, "Healthy", 20.00m, 2.3m, 320);

            // Add animals to zoo
            zoo.AddAnimal(lion);
            zoo.AddAnimal(elephant);
            zoo.AddAnimal(parrot);
            zoo.AddAnimal(snake);
            zoo.AddAnimal(eagle);

            // Create zookeepers
            var keeper1 = new ZooKeeper("K001", "John Smith", "Mammals");
            var keeper2 = new ZooKeeper("K002", "Jane Doe", "Birds and Reptiles");

            zoo.ZooKeepers.Add(keeper1);
            zoo.ZooKeepers.Add(keeper2);

            // Assign animals to keepers
            zoo.AssignAnimalToKeeper(lion, keeper1);
            zoo.AssignAnimalToKeeper(elephant, keeper1);
            zoo.AssignAnimalToKeeper(parrot, keeper2);
            zoo.AssignAnimalToKeeper(snake, keeper2);
            zoo.AssignAnimalToKeeper(eagle, keeper2);

            // Display all animals
            var animalList = zoo.DisplayAllAnimals();
            foreach (var animal in animalList)
            {
                Console.WriteLine($"{animal.AnimalID} - {animal.Name} ({animal.Species}) - Age: {animal.Age} - Habitat: {animal.GetHabitat()}");
            }

            //// Demonstrate polymorphism
            Console.WriteLine("\nAnimal Sound");
            foreach (var animal in zoo.Animals)
            {
                Console.WriteLine($"{animal.Name} says: {animal.MakeSound()}");
            }

            //// Get animals by habitat
            Console.WriteLine("\nGet Animal By Habitat");
            var animalListByHabitat = zoo.GetAnimalsByHabitat("Savanna");
            foreach (var animal in animalListByHabitat)
            {
                Console.WriteLine($"- {animal.Name} ({animal.Species})");
            }

            //// Calculate costs
            Console.WriteLine();
            var totalWeeklyCost = zoo.CalculateTotalWeeklyCost();
            Console.WriteLine($"Total weekly cost: {totalWeeklyCost}");

            //// Zookeeper work
            Console.WriteLine();
            keeper1.FeedAnimal(lion);
            keeper1.CheckAnimalHealth(elephant);
            Console.WriteLine(keeper1.Name + "'s workload: " + keeper1.GetWorkLoad() + " animals");

            //// Zoo statistics
            Console.WriteLine();
            Console.WriteLine(zoo.GetZooStatistics());         }
    }
}
