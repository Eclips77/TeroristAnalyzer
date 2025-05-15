using System;
using System.Collections.Generic;

namespace TeroristAnalyzer
{
    internal class Program
    {
         class Terrorist
        {
            public string Name { get; set; }
            public string Weapons { get; set; }
            public int Age { get; set; }
            public (string Lat,string Lon) GpsLocation { get; set; }
            public string Affiliation { get; set; }
            
        }

        static Random rnd = new Random();
        static void Main(string[] args)
        {
            List<Terrorist> terrorists = GetTerroristData();
            PrintTerrorist(terrorists);
            
        }

        static int ShowMenu()
        {
            Console.WriteLine("choose one of the option 1-6:");
            Console.WriteLine("1. find the most common weapon:");
            Console.WriteLine("2. find the least common weapon:");
            Console.WriteLine("3. find the organization with the most members:");
            Console.WriteLine("4. find the organization with the least members:");
            Console.WriteLine("5. find the 2 terrorists who are closest to each other:");
            Console.WriteLine("6. exit:");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        static List<Terrorist> GetTerroristData()
        {
            List<Terrorist> Terror = new List<Terrorist>();
            for (int i = 0; i < 20 ; i++)
            {
                Terror.Add(GetTerrorist());

            }
            return Terror;
        }

        static Terrorist GetTerrorist()
        {
           
            string[] names = { "muhamad", "aziz","ahmed","fatma" };
            string[] weapons = { "m-16", "hendgun","grande","ak-47" };
            string[] organization = { "hamas", "jihad islami" };

            Terrorist terrorist = new Terrorist();
            terrorist.Name = names[rnd.Next(0,names.Length)];
            terrorist.Weapons = weapons[rnd.Next(0,weapons.Length)];
            terrorist.Age = rnd.Next(0, 120);
            string Lat = $"{rnd.NextDouble() * 100:F2}";
            string Lon = $"{rnd.NextDouble() * 100:F2}";
            terrorist.GpsLocation = (Lat, Lon);
            terrorist.Affiliation = organization[rnd.Next(0,organization.Length)];
            return terrorist;
        }

        static void PrintTerrorist(List<Terrorist> terrorists)
        {
            foreach (var terrorist in terrorists)
            {
                Console.WriteLine($"name: {terrorist.Name}");
                Console.WriteLine($"weapon: {terrorist.Weapons}");
                Console.WriteLine($"age: {terrorist.Age}");
                Console.WriteLine($"locaition: ({terrorist.GpsLocation.Lat}, {terrorist.GpsLocation.Lon})");
                Console.WriteLine($"affiliation: {terrorist.Affiliation}");
                Console.WriteLine("\n");
            }
        }
          
    
      
    }
}


     
