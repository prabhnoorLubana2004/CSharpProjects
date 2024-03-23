using System;

class person
{
    // Attributes
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FavoriteColour { get; set; }
    public int Age { get; set; }
    public bool IsWorking { get; set; }

    // Constructor
    public person(int personId, string firstName, string lastName, string favoriteColour, int age, bool isWorking)
    {
        PersonId = personId;
        FirstName = firstName;
        LastName = lastName;
        FavoriteColour = favoriteColour;
        Age = age;
        IsWorking = isWorking;
    }

    // Methods

    // DisplayPersonInfo method
    public void DisplayPersonInfo()
    {
        Console.WriteLine($"Name= {FirstName} {LastName}\npersonId: {PersonId} Name’s favorite color is {FavoriteColour}");
    }

    // ChangeFavoriteColour method
    public void ChangeFavoriteColour()
    {
        FavoriteColour = "white";
        Console.WriteLine($"{FirstName}'s favorite color has been changed to white.");
    }

    // GetAgeInTenYears method
    public int GetAgeInTenYears()
    {
        return Age + 10;
    }

    // ToString method
    public override string ToString()
    {
        return $"PersonId: {PersonId}\nFirstName: {FirstName}\nLastName: {LastName}\nFavoriteColour: {FavoriteColour}\nAge: {Age}\nIsWorking: {IsWorking}";
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        person person1 = new person(1, "John", "Doe", "Blue", 25, true);

        // Display information
        person1.DisplayPersonInfo();

        // Change favorite color
        person1.ChangeFavoriteColour();
        Console.WriteLine($"New favorite color: {person1.FavoriteColour}");

        // Get age after 10 years
        int ageInTenYears = person1.GetAgeInTenYears();
        Console.WriteLine($"Age after 10 years: {ageInTenYears}");

        // Display all information using ToString method
        Console.WriteLine(person1.ToString());
    }
}

