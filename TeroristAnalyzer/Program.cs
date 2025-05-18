using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TeroristAnalyzer
{
    internal class Program
    {
        class Terrorist
        {
            public string Name { get; set; }
            public string Weapons { get; set; }
            public int Age { get; set; }
            public (string Lat, string Lon) GpsLocation { get; set; }
            public string Affiliation { get; set; }
        }

        static Random rnd = new Random();
        static void Main(string[] args)
        {
            List<Terrorist> terrorists = GetTerroristData();
            //PrintTerrorist(terrorists);
            bool running = true;
            while (running)
            {
                string choice = ShowMenu();
                if (Manager(choice, terrorists)) running = false;
            }
        }

        static bool Manager(string choice, List<Terrorist> terrorists)
        {
            switch (choice)
            {
                case "1":
                    ShowMostWeapon(terrorists);
                    break;
                case "2":
                    ShowLeastWeapon(terrorists);
                    break;
                case "3":
                    MosrMembers(terrorists);
                    break;
                case "4":
                    LeastMembers(terrorists);
                    break;
                case "5":
                    ClosetTerrorist(terrorists);
                    break;
                case "6":
                    return true;
                default:
                    Console.WriteLine("invalid choice please try again:");
                    break;
            }
            return false;
        }

        static string ShowMenu()
        {
            Console.WriteLine("choose one of the option 1-6:");
            Console.WriteLine("1. find the most common weapon:");
            Console.WriteLine("2. find the least common weapon:");
            Console.WriteLine("3. find the organization with the most members:");
            Console.WriteLine("4. find the organization with the least members:");
            Console.WriteLine("5. find the 2 terrorists who are closest to each other:");
            Console.WriteLine("6. exit:");
            string choice = Console.ReadLine();
            return choice;
        }

        static List<Terrorist> GetTerroristData()
        {
            List<Terrorist> Terror = new List<Terrorist>();
            for (int i = 0; i < 20; i++)
            {
                Terror.Add(GetTerrorist());
            }
            return Terror;
        }

        static Terrorist GetTerrorist()
        {
            string[] names = { "muhamad", "aziz", "ahmed", "fatma" };
            string[] weapons = { "m-16", "hendgun", "grande", "ak-47" };
            string[] organization = { "hamas", "jihad islami" };

            Terrorist terrorist = new Terrorist();
            terrorist.Name = names[rnd.Next(0, names.Length)];
            terrorist.Weapons = weapons[rnd.Next(0, weapons.Length)];
            terrorist.Age = rnd.Next(0, 120);
            string Lat = $"{rnd.NextDouble() * 100:F2}";
            string Lon = $"{rnd.NextDouble() * 100:F2}";
            terrorist.GpsLocation = (Lat, Lon);
            terrorist.Affiliation = organization[rnd.Next(0, organization.Length)];
            return terrorist;
        }

        static void ShowMostWeapon(List<Terrorist> terrorists)
        {
            string[] weapons = new string[terrorists.Count];
            int[] counts = new int[terrorists.Count];
            int unique = 0;

            for (int i = 0; i < terrorists.Count; i++)
            {
                bool found = false;
                for (int j = 0; j < unique; j++)
                {
                    if (terrorists[i].Weapons == weapons[j])
                    {
                        counts[j]++;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    weapons[unique] = terrorists[i].Weapons;
                    counts[unique] = 1;
                    unique++;
                }
            }

            int max = 0;
            string mostWeapon = "";
            for (int i = 0; i < unique; i++)
            {
                if (counts[i] > max)
                {
                    max = counts[i];
                    mostWeapon = weapons[i];
                }
            }
            Console.WriteLine($"The most common weapon is {mostWeapon} with {max} occurrences.");
        }

        static void ShowLeastWeapon(List<Terrorist> terrorists)
        {
            string[] weapons = new string[terrorists.Count];
            int[] counts = new int[terrorists.Count];
            int unique = 0;

            for (int i = 0; i < terrorists.Count; i++)
            {
                bool found = false;
                for (int j = 0; j < unique; j++)
                {
                    if (terrorists[i].Weapons == weapons[j])
                    {
                        counts[j]++;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    weapons[unique] = terrorists[i].Weapons;
                    counts[unique] = 1;
                    unique++;
                }
            }

            int min = terrorists.Count + 1;
            string leastWeapon = "";
            for (int i = 0; i < unique; i++)
            {
                if (counts[i] < min)
                {
                    min = counts[i];
                    leastWeapon = weapons[i];
                }
            }
            Console.WriteLine($"The least common weapon is {leastWeapon} with {min} occurrences.");
        }

        static void MosrMembers(List<Terrorist> terrorists)
        {
            string[] orgs = new string[terrorists.Count];
            int[] counts = new int[terrorists.Count];
            int unique = 0;

            for (int i = 0; i < terrorists.Count; i++)
            {
                bool found = false;
                for (int j = 0; j < unique; j++)
                {
                    if (terrorists[i].Affiliation == orgs[j])
                    {
                        counts[j]++;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    orgs[unique] = terrorists[i].Affiliation;
                    counts[unique] = 1;
                    unique++;
                }
            }

            int max = 0;
            string mostOrg = "";
            for (int i = 0; i < unique; i++)
            {
                if (counts[i] > max)
                {
                    max = counts[i];
                    mostOrg = orgs[i];
                }
            }
            Console.WriteLine($"\nThe organization with most members is {mostOrg} with {max} members.");
        }

        static void LeastMembers(List<Terrorist> terrorists)
        {
            string[] orgs = new string[terrorists.Count];
            int[] counts = new int[terrorists.Count];
            int unique = 0;

            for (int i = 0; i < terrorists.Count; i++)
            {
                bool found = false;
                for (int j = 0; j < unique; j++)
                {
                    if (terrorists[i].Affiliation == orgs[j])
                    {
                        counts[j]++;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    orgs[unique] = terrorists[i].Affiliation;
                    counts[unique] = 1;
                    unique++;
                }
            }

            int min = terrorists.Count + 1;
            string leastOrg = "";
            for (int i = 0; i < unique; i++)
            {
                if (counts[i] < min)
                {
                    min = counts[i];
                    leastOrg = orgs[i];
                }
            }
            Console.WriteLine($"\nThe organization with least members is {leastOrg} with {min} members.");
        }

        static void ClosetTerrorist(List<Terrorist> terrorists)
        {
            double minDistance = double.MaxValue;
            string name1 = "";
            string name2 = "";

            for (int i = 0; i < terrorists.Count; i++)
            {
                for (int j = i + 1; j < terrorists.Count; j++)
                {
                    double lat1 = double.Parse(terrorists[i].GpsLocation.Lat);
                    double lon1 = double.Parse(terrorists[i].GpsLocation.Lon);
                    double lat2 = double.Parse(terrorists[j].GpsLocation.Lat);
                    double lon2 = double.Parse(terrorists[j].GpsLocation.Lon);

                    double distance = Math.Sqrt(Math.Pow(lat2 - lat1, 2) + Math.Pow(lon2 - lon1, 2));

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        name1 = terrorists[i].Name;
                        name2 = terrorists[j].Name;
                    }
                }
            }
            Console.WriteLine($"\nThe closest terrorists are {name1} and {name2} with distance {minDistance:F2}.");
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