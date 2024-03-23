using System;
using System.Collections.Generic;


interface IAnimal
{
    string Name { get; set; }
    string Colour { get; set; }
    double Height { get; set; }
    int Age { get; set; }

 
    void Eat();
    string Cry();
}

class Dog : IAnimal
{
   
    public string Name { get; set; }
    public string Colour { get; set; }
    public double Height { get; set; }
    public int Age { get; set; }

   
    public void Eat()
    {
        Console.WriteLine("Dogs eat meat.");
    }

    public string Cry()
    {
        return "Woof!";
    }
}

class Cat : IAnimal
{
   
    public string Name { get; set; }
    public string Colour { get; set; }
    public double Height { get; set; }
    public int Age { get; set; }

    public void Eat()
    {
        Console.WriteLine("Cats eat mice.");
    }

  
    public string Cry()
    {
        return "Meow!";
    }
}

class Program
{
    static void Main(string[] args)
    {
      
        Dog dog = new Dog();
        Console.WriteLine("Enter dog's name:");
        dog.Name = Console.ReadLine();
        Console.WriteLine("Enter dog's height:");
        dog.Height = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter dog's colour:");
        dog.Colour = Console.ReadLine();
        Console.WriteLine("Enter dog's age:");
        dog.Age = int.Parse(Console.ReadLine());

        
        Console.WriteLine($"Dog's name: {dog.Name}");
        Console.WriteLine($"Dog's height: {dog.Height}");
        Console.WriteLine($"Dog's colour: {dog.Colour}");
        Console.WriteLine($"Dog's age: {dog.Age}");
        dog.Eat();
        Console.WriteLine($"Dog says: {dog.Cry()}");

        
        Cat cat = new Cat();
        Console.WriteLine("\nEnter cat's name:");
        cat.Name = Console.ReadLine();
        Console.WriteLine("Enter cat's height:");
        cat.Height = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter cat's colour:");
        cat.Colour = Console.ReadLine();
        Console.WriteLine("Enter cat's age:");
        cat.Age = int.Parse(Console.ReadLine());

        Console.WriteLine($"Cat's name: {cat.Name}");
        Console.WriteLine($"Cat's height: {cat.Height}");
        Console.WriteLine($"Cat's colour: {cat.Colour}");
        Console.WriteLine($"Cat's age: {cat.Age}");
        cat.Eat();
        Console.WriteLine($"Cat says: {cat.Cry()}");

    
        List<IAnimal> animals = new List<IAnimal>();
        animals.Add(dog);
        animals.Add(cat);

        
        Console.WriteLine("\nNames of all the animals:");
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.Name);
        }

        Console.ReadLine(); 
    }
}
