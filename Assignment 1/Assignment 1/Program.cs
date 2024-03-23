
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

// Shared characteristics for all appliances
public class Appliance
{
    public string ItemNumber { get; set; }
    public string Brand { get; set; }
    public int Quantity { get; set; }
    public int Wattage { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }

    // Create a string for each appliance
    public virtual string ToStringFormatted()
    {
        return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price:C}";
    }

    public Appliance(string itemNumber, string brand, int quantity, int wattage, string color, decimal price)
    {
        ItemNumber = itemNumber;
        Brand = brand;
        Quantity = quantity;
        Wattage = wattage;
        Color = color;
        Price = price;
    }
}

// Refrigerator characteristics
public class Refrigerator : Appliance
{
    public int NumberOfDoors { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public Refrigerator(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, int numberOfDoors, int height, int width)
        : base(itemNumber, brand, quantity, wattage, color, price)
    {
        NumberOfDoors = numberOfDoors;
        Height = height;
        Width = width;
    }

    public override string ToStringFormatted()
    {
        return base.ToStringFormatted() + $"\nNumber of Doors: {NumberOfDoors}\nHeight: {Height} inches\nWidth: {Width} inches";
    }
}

// Vacuum characteristics
public class Vacuum : Appliance
{
    public string Grade { get; set; }
    public int BatteryVoltage { get; set; }

    public Vacuum(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, string grade, int batteryVoltage)
        : base(itemNumber, brand, quantity, wattage, color, price)
    {
        Grade = grade;
        BatteryVoltage = batteryVoltage;
    }

    public override string ToStringFormatted()
    {
        return base.ToStringFormatted() + $"\nGrade: {Grade}\nBattery Voltage: {BatteryVoltage} V";
    }
}

// Room Options
public enum RoomType
{
    Kitchen,
    WorkSite
}

// Microwave characteristics
public class Microwave : Appliance
{
    public decimal Capacity { get; set; }
    public RoomType RoomType { get; set; }

    public Microwave(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, decimal capacity, RoomType roomType)
        : base(itemNumber, brand, quantity, wattage, color, price)
    {
        Capacity = capacity;
        RoomType = roomType;
    }

    public override string ToStringFormatted()
    {
        string roomTypeString = RoomType == RoomType.Kitchen ? "Kitchen" : "Work Site";
        return base.ToStringFormatted() + $"\nCapacity: {Capacity} cu. ft\nRoom Type: {roomTypeString}";
    }
}

// Dishwasher characteristics
public class Dishwasher : Appliance
{
    public string SoundRating { get; set; }
    public string Feature { get; set; }

    public Dishwasher(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, string soundRating, string feature)
        : base(itemNumber, brand, quantity, wattage, color, price)
    {
        SoundRating = soundRating;
        Feature = feature;
    }

    public override string ToStringFormatted()
    {
        string soundRatingString;
        switch (SoundRating)
        {
            case "Qt":
                soundRatingString = "Quietest";
                break;
            case "Qr":
                soundRatingString = "Quieter";
                break;
            case "Qu":
                soundRatingString = "Quiet";
                break;
            case "M":
                soundRatingString = "Moderate";
                break;
            default:
                soundRatingString = "Unknown";
                break;
        }

        return base.ToStringFormatted() + $"\nSound Rating: {soundRatingString}\nFeature: {Feature}";
    }
}

public class Program
{
    private static List<Appliance> appliances = new List<Appliance>();

    public static void Main(string[] args)
    {
        ReadAppliancesFromFile("appliances.txt");

        Console.WriteLine("Welcome to Modern Appliances!");
        Console.WriteLine("How May We Assist You?");
        Console.WriteLine("1 – Check out appliance");
        Console.WriteLine("2 – Find appliances by brand");
        Console.WriteLine("3 – Display appliances by type");
        Console.WriteLine("4 – Produce random appliance list");
        Console.WriteLine("5 – Save & exit");
        Console.Write("Enter option: ");

        int option;
        if (!int.TryParse(Console.ReadLine(), out option))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            Main(args); // Loop back to the main method
            return;
        }

        switch (option)
        {
            case 1:
                PurchaseAppliance();
                break;
            case 2:
                SearchByBrand();
                break;
            case 3:
                DisplayAppliancesByType();
                break;
            case 4:
                ProduceRandomApplianceList();
                break;
            case 5:
                SaveAndExit();
                break;
            default:
                Console.WriteLine("Invalid option. Please select a valid option (1-5).");
                Main(args); // Loop back to the main method
                break;
        }
    }

    private static void ReadAppliancesFromFile(string fileName)
    {
        // Constructing the full file path
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);


        // Reading the lines from the file
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            string itemNumber = parts[0];
            string brand = parts[1];
            int quantity = int.Parse(parts[2]);
            int wattage = int.Parse(parts[3]);
            string color = parts[4];
            decimal price = decimal.Parse(parts[5]);

            switch (itemNumber[0])
            {
                case '1':
                    int numberOfDoors = int.Parse(parts[5]); 
                    int height = int.Parse(parts[5]); 
                    int width = int.Parse(parts[5]); 
                    appliances.Add(new Refrigerator(itemNumber, brand, quantity, wattage, color, price, numberOfDoors, height, width));
                    break;
                case '2':
                    string grade = parts[5]; 
                    int batteryVoltage = int.Parse(parts[5]); 
                    appliances.Add(new Vacuum(itemNumber, brand, quantity, wattage, color

, price, grade, batteryVoltage));
                    break;
                case '3':
                    decimal capacity = decimal.Parse(parts[5]); 
                    RoomType roomType = parts[5] == "K" ? RoomType.Kitchen : RoomType.WorkSite; 
                    appliances.Add(new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType));
                    break;
                case '4':
                case '5':
                    string soundRating = parts[5]; 
                    string feature = parts[5]; 
                    appliances.Add(new Dishwasher(itemNumber, brand, quantity, wattage, color, price, soundRating, feature));
                    break;
                default:
                    Console.WriteLine($"Unknown appliance type: {itemNumber[0]}");
                    break;
            }
        }
    }

    private static void PurchaseAppliance()
    {
        Console.WriteLine("Enter the item number of an appliance:");
        string itemNumber = Console.ReadLine();
        Appliance selectedAppliance = appliances.FirstOrDefault(appliance => appliance.ItemNumber == itemNumber);

        if (selectedAppliance != null)
        {
            if (selectedAppliance.Quantity > 0)
            {
                selectedAppliance.Quantity--;
                Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.");
            }
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
        }
        else
        {
            Console.WriteLine("No appliances found with that item number.");
        }

        Main(null); // Loop back to the main method
    }

    private static void SearchByBrand()
    {
        Console.Write("Enter brand to search for: ");
        string brand = Console.ReadLine();
        var matchingAppliances = appliances.Where(appliance => appliance.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Matching Appliances:");
        foreach (var appliance in matchingAppliances)
        {
            Console.WriteLine(appliance.ToStringFormatted());
        }

        Main(null); // Loop back to the main method
    }

    private static void DisplayAppliancesByType()
    {
        Console.WriteLine("Appliance Types");
        Console.WriteLine("1 – Refrigerators");
        Console.WriteLine("2 – Vacuums");
        Console.WriteLine("3 – Microwaves");
        Console.WriteLine("4 – Dishwashers");
        Console.Write("Enter type of appliance: ");
        int typeOption = int.Parse(Console.ReadLine());

        switch (typeOption)
        {
            case 1:
                DisplayRefrigerators();
                break;
            case 2:
                DisplayVacuums();
                break;
            case 3:
                DisplayMicrowaves();
                break;
            case 4:
                DisplayDishwashers();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        Main(null); // Loop back to the main method
    }

    private static void DisplayRefrigerators()
    {
        Console.Write("Enter number of doors: ");
        int numberOfDoors = int.Parse(Console.ReadLine());
        var matchingRefrigerators = appliances.OfType<Refrigerator>().Where(refrigerator => refrigerator.NumberOfDoors == numberOfDoors);
        Console.WriteLine("Matching refrigerators:");
        foreach (var refrigerator in matchingRefrigerators)
        {
            Console.WriteLine(refrigerator.ToStringFormatted());
        }

        Main(null); // Loop back to the main method
    }

    private static void DisplayVacuums()
    {
        Console.Write("Enter battery voltage value. 18 V (low) or 24 V (high): ");
        int batteryVoltage = int.Parse(Console.ReadLine());
        var matchingVacuums = appliances.OfType<Vacuum>().Where(vacuum => vacuum.BatteryVoltage == batteryVoltage);
        Console.WriteLine("Matching vacuums:");
        foreach (var vacuum in matchingVacuums)
        {
            Console.WriteLine(vacuum.ToStringFormatted());
        }

        Main(null); // Loop back to the main method
    }

    private static void DisplayMicrowaves()
    {
        Console.Write("Enter room where the microwave will be installed: K (kitchen) or W (work site): ");
        RoomType roomType = Console.ReadLine().ToUpper() == "K" ? RoomType.Kitchen : RoomType.WorkSite;
        var matchingMicrowaves = appliances.OfType<Microwave>().Where(microwave => microwave.RoomType == roomType);
        Console.WriteLine("Matching microwaves:");
        foreach (var microwave in matchingMicrowaves)
        {
            Console.WriteLine(microwave.ToStringFormatted());
        }

        Main(null); // Loop back to the main method
    }

    private static void DisplayDishwashers()
    {
        Console.Write("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu (Quiet) or M (Moderate): ");
        string soundRating = Console.ReadLine();
        var matchingDishwashers = appliances.OfType<Dishwasher>().Where(dishwasher => dishwasher.SoundRating == soundRating);
        Console.WriteLine("Matching dishwashers:");
        foreach (var dishwasher in matchingDishwashers)
        {
            Console.WriteLine(dishwasher.ToStringFormatted());
        }

        Main(null); // Loop back to the main method
    }

    private static void ProduceRandomApplianceList()
    {
        Console.Write("Enter number of appliances: ");
        int count = int.Parse(Console.ReadLine());
        var random = new Random();
        Console.WriteLine("Random appliances:");
        for (int i = 0; i < count; i++)
        {
            int randomIndex = random.Next(appliances.Count);
            Console.WriteLine(appliances[randomIndex].ToStringFormatted());
        }

        Main(null); // Loop back to the main method
    }

    private static void SaveAndExit()
    {
        WriteAppliancesToFile("appliances.txt");
        Console.WriteLine("Appliances saved. Exiting program.");
    }

    private static void WriteAppliancesToFile(string fileName)
    {
        // Constructing the full file path
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var appliance in appliances)
            {
                writer.WriteLine($"{appliance.ItemNumber};{appliance.Brand};{appliance.Quantity};{appliance.Wattage};{appliance.Color};{appliance.Price}");
            }
        }
    }
}
