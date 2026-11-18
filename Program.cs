using KempingFoglalas;
using System.IO;

List<Foglalas> kemping = new List<Foglalas>();

Console.WriteLine("Adatok beolvasása a kemping.txt fájlból...\n");
Console.WriteLine("Rögzített kempingfoglalások:");

foreach (var sor in File.ReadAllLines("kemping.txt").Skip(1))
{
    Foglalas peldany = new Foglalas(sor);
    kemping.Add(peldany);
    Console.WriteLine(peldany);
}

Console.WriteLine("\nÖsszesített statisztika:");
Console.WriteLine($"Kemping teljes bevétele: {kemping.Sum(x=>x.FizetendoOsszeg())} Ft");
Console.WriteLine($"Összes vendég létszáma: {kemping.Sum(x=>x.FelnottFo)+ kemping.Sum(x => x.GyerekFo)} fő");
Console.WriteLine($"Átlagos tartózkodási idő: {kemping.Average(x=>x.EjszakakSzama)} éjszaka");
Console.WriteLine($"Legtöbbet fizető vendég: {kemping.MaxBy(x=>x.FizetendoOsszeg()).VendegNev} ({Math.Round(kemping.Max(x=>x.FizetendoOsszeg()))} Ft)");
Console.WriteLine($"Gyerekes KOMFORT foglalások száma: {kemping.Count(x=>x.GyerekFo>0 && x.ParcellaTipus=="KOMFORT")} db");
Console.WriteLine($"\nKedvezményre jogosult vendégek (legalább 5 éjszaka):");

foreach (var sor in kemping)
{
    if (sor.EjszakakSzama>=5) 
    { 
        Console.WriteLine($"{sor.VendegNev} ({sor.EjszakakSzama} éjszaka)");
    } 
    
}
