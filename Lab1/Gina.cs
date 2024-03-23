using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public int PersonId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string FavoriteColour { get; set; }
    public int Age { get; }
    public bool IsWorking { get; }

    public Person(int personId, string firstName, string lastName, string favoriteColour, int age, bool isWorking)
    {
        PersonId = personId;
        FirstName = firstName;
        LastName = lastName;
        FavoriteColour = favoriteColour;
        Age = age;
        IsWorking = isWorking;
    }
}

class Relation
{
    public string RelationshipType { get; }

    public Relation(string relationshipType)
    {
        RelationshipType = relationshipType;
    }

    public void ShowRelationship(Person person1, Person person2)
    {
        Console.WriteLine($"{person1.FirstName} and {person2.FirstName} are {RelationshipType}");
    }
}

class MainClass
{
    static void Main()
    {
        
        Person person1 = new Person(1, "Ian", "Brooks", "Red", 30, true);
        Person person2 = new Person(2, "Gina", "James", "Green", 18, false);
        Person person3 = new Person(3, "Mike", "Briscoe", "Blue", 45, true);
        Person person4 = new Person(4, "Mary", "Beals", "Yellow", 28, true);

        Console.WriteLine($"{person2.FirstName}'s information: ID: {person2.PersonId}, First Name: {person2.FirstName}, Last Name: {person2.LastName}, Favorite Colour: {person2.FavoriteColour}");

        
        Console.WriteLine($"Mike's information:\nID: {person3.PersonId}, First Name: {person3.FirstName}, Last Name: {person3.LastName}, Favorite Colour: {person3.FavoriteColour}, Age: {person3.Age}, Is Working: {person3.IsWorking}");

        person1.FavoriteColour = "White";
       
        Console.WriteLine($"{person1.FirstName}'s information after changing favorite colour: ID: {person1.PersonId}, First Name: {person1.FirstName}, Last Name: {person1.LastName}, Favorite Colour: {person1.FavoriteColour}");

       
        Console.WriteLine($"Mary's age after ten years: {person4.Age + 10}");

       
        Relation relation1 = new Relation("Sisters");
        Relation relation2 = new Relation("Brothers");

        relation1.ShowRelationship(person2, person4);
        relation2.ShowRelationship(person1, person3);

        List<Person> peopleList = new List<Person> { person1, person2, person3, person4 };

      
        double averageAge = peopleList.Average(p => p.Age);
        Console.WriteLine($"Average Age: {averageAge}");

        Person youngestPerson = peopleList.OrderBy(p => p.Age).First();
        Person oldestPerson = peopleList.OrderByDescending(p => p.Age).First();
        Console.WriteLine($"Youngest Person: {youngestPerson.FirstName}, Oldest Person: {oldestPerson.FirstName}");

       
        List<string> namesWithM = peopleList.Where(p => p.FirstName.StartsWith("M")).Select(p => p.FirstName).ToList();
        Console.WriteLine($"People whose first names start with M: {string.Join(", ", namesWithM)}");

        Person personWithBlue = peopleList.Find(p => p.FavoriteColour.Equals("Blue"));
        Console.WriteLine($"Person who likes the colour blue: ID: {personWithBlue.PersonId}, First Name: {personWithBlue.FirstName}, Last Name: {personWithBlue.LastName}, Age: {personWithBlue.Age}, Is Working: {personWithBlue.IsWorking}");
    }
}
