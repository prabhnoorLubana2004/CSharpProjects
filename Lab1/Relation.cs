using System;

class Person
{
    public string Name { get; }

    public Person(string name)
    {
        Name = name;
    }
}

class relation
{
    public string RelationshipType { get; }

    public relation(string relationshipType)
    {
        RelationshipType = relationshipType;
    }

    public void ShowRelationship(Person person1, Person person2)
    {
        Console.WriteLine($"{person1.Name} is {RelationshipType} of {person2.Name}");
    }
}

class Program
{
    static void Main()
    {
        
     
        Person person1 = new Person("Alice");
        Person person2 = new Person("Bob");

        
        relation relationship = new relation("Sister");

        
        relationship.ShowRelationship(person1, person2);
    }
}
