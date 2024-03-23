using System;


abstract class Animal
{
    
    public string Name { get; set; }
    public string Colour { get; set; }
    public int Age { get; set; }

    
    public Animal(string name, string colour, int age)
    {
        Name = name;
        Colour = colour;
        Age = age;
    }

    
    public abstract void Eat();
}


class Dog : Animal
{
    
    public Dog(string name, string colour, int age) : base(name, colour, age) { }


    public override void Eat()
    {
        Console.WriteLine("Dogs eat meat.");
    }
}


class Cat : Animal
{
    
    public Cat(string name, string colour, int age) : base(name, colour, age) { }

    
    public override void Eat()
    {
        Console.WriteLine("Cats eat mice.");
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Console.WriteLine("Enter dog's name:");
        string dogName = Console.ReadLine();

        Console.WriteLine("Enter dog's color:");
        string dogColor = Console.ReadLine();

        Console.WriteLine("Enter dog's age:");
        int dogAge = int.Parse(Console.ReadLine());

       
        Dog dog = new Dog(dogName, dogColor, dogAge);

        Console.WriteLine($"Dog's name: {dog.Name}");
        Console.WriteLine($"Dog's color: {dog.Colour}");
        Console.WriteLine($"Dog's age: {dog.Age}");
        dog.Eat();

        
        Console.WriteLine("\nEnter cat's name:");
        string catName = Console.ReadLine();

        Console.WriteLine("Enter cat's color:");
        string catColor = Console.ReadLine();

        Console.WriteLine("Enter cat's age:");
        int catAge = int.Parse(Console.ReadLine());

       
        Cat cat = new Cat(catName, catColor, catAge);

       
        Console.WriteLine($"Cat's name: {cat.Name}");
        Console.WriteLine($"Cat's color: {cat.Colour}");
        Console.WriteLine($"Cat's age: {cat.Age}");
        cat.Eat();

        Console.ReadLine(); 
    }
}

