List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");


// Execute Assignment Tasks here! -------------------------------------------

// Use LINQ to find the first eruption that is in Chile and print the result.
IEnumerable<Eruption> firstChile = eruptions.Where(c => c.Location == "Chile").Where(y => y.Year == 1963);
PrintEach(firstChile, "First eruption that is in chile");

// Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
IEnumerable<Eruption> HawaiianIs = eruptions.Where(c => c.Location == "Hawaiian Is").Take(1);
List<Eruption> HawaiianList = HawaiianIs.ToList();
if(HawaiianList.Count == 0)
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
} else {
PrintEach(HawaiianIs, "First eruption from Hawaiian Is");
}

// Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
IEnumerable<Eruption> Greenland = eruptions.Where(c => c.Location == "Greenland").Take(1);
List<Eruption> GreenList = Greenland.ToList();
if(GreenList.Count == 0)
{
    Console.WriteLine("No Greenland Eruption found.");
} else {
PrintEach(Greenland, "First eruption from Greenland");
}

// Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
IEnumerable<Eruption> NZ1990 = eruptions.Where(y=>y.Year > 1900).Where(l=>l.Location == "New Zealand").Take(1);
PrintEach(NZ1990, "First eruption that is after 1990 and in New Zealand");

// Find all eruptions where the volcano's elevation is over 2000m and print them.
IEnumerable<Eruption> Over2000 = eruptions.Where(e=>e.ElevationInMeters > 2000);
PrintEach(Over2000, "All eruptions over 2000m in Elevation");

// Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
List<Eruption> NameStartsWithL = eruptions.Where(l=>l.Volcano.StartsWith("L")).ToList();
PrintEach(NameStartsWithL, $"All Volcanoes where the name starts with an L, we found {NameStartsWithL.Count}!");

// Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int HighestElevation = eruptions.Max(e=>e.ElevationInMeters);
Console.WriteLine(" ");
Console.WriteLine($"The highest elevation found in the list is {HighestElevation}!");

// Use the highest elevation variable to find a print the name of the Volcano with that elevation.
IEnumerable<string> HEVolcano = eruptions.Where(e=>e.ElevationInMeters==HighestElevation).Select(v=>v.Volcano);
Console.WriteLine(" ");
foreach (string item in HEVolcano)
{
    Console.WriteLine($"The Volcano this elevation belongs to is {item}!");
}

// Print all Volcano names alphabetically.
IEnumerable<string> AlphaVolNames = eruptions.OrderBy(v=>v.Volcano).Select(v=>v.Volcano);
Console.WriteLine(" ");
Console.WriteLine("All Volcanoes, by name, alphabetically:");
Console.WriteLine(" ");
foreach (string item in AlphaVolNames)
{
    Console.WriteLine(item);
}

// Print the sum of all the elevations of the volcanoes combined.
int ElevSum = eruptions.Sum(e=>e.ElevationInMeters);
Console.WriteLine(" ");
Console.WriteLine($"The sum of all the elevations of the volcanoes combined is {ElevSum}.");

// Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
bool Yr2000 = eruptions.Any(y=>y.Year == 2000);
Console.WriteLine(" ");
Console.WriteLine($"Did any volcanoes erupt in the year 2000? (True/False) The answer is: {Yr2000}");

// Find all stratovolcanoes and print just the first three (Hint: look up Take)
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions; first three results.");

// Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
IEnumerable<Eruption> B1000 = eruptions.Where(y=>y.Year < 1000).OrderBy(v=>v.Volcano);
PrintEach(B1000, "Eruptions that happened before the year 1000 CE alphabetically according to Volcano name.");

// Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
IEnumerable<string> B1000Names = eruptions.Where(y=>y.Year < 1000).OrderBy(v=>v.Volcano).Select(v=>v.Volcano);
Console.WriteLine(" ");
foreach (string item in B1000Names)
{
    Console.WriteLine(item);
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}