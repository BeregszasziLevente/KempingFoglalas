using KempingFoglalas;
using System.IO;

List<Foglalas> kemping = new List<Foglalas>(); 

foreach (var sor in File.ReadAllLines("kemping.txt").Skip(1))
{
    Foglalas peldany = new Foglalas(sor);
    kemping.Add(peldany);
}