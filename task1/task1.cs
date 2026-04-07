using System;
using System.Collections.Generic;

namespace laba_4;

public class City
{
    public string Name;
    public int Population;

    public City(string name, int population)
    {
        this.Name = name;
        this.Population = population;
    }

    public override string ToString() => $"{Name} (населення: {Population})";

    public override bool Equals(object? obj)
    {
        if (obj is City other) return this.Name == other.Name;
        return false;
    }

    public override int GetHashCode() => Name.GetHashCode();
}

public class District
{
    public string Name;
    public City[] Cities;

    public District(string name, City[] cities)
    {
        this.Name = name;
        this.Cities = cities;
        Console.WriteLine("створено район: " + name);
    }
}

public class Region
{
    public string Name;
    public double Area;
    public City Center;
    public District[] Districts;

    public Region(string name, double area, City center, District[] districts)
    {
        this.Name = name;
        this.Area = area;
        this.Center = center;
        this.Districts = districts;
        Console.WriteLine("створено область: " + name);
    }
}

public class Country
{
    public string Name;
    public City Capital;
    public Region[] Regions;

    public Country(string name, City capital, Region[] regions)
    {
        this.Name = name;
        this.Capital = capital;
        this.Regions = regions;
        Console.WriteLine("створено об'єкт Держава: " + name);
    }

    public void printCapital() => Console.WriteLine("столиця: " + Capital);
    public void printRegionsCount() => Console.WriteLine("кількість областей: " + Regions.Length);

    public void printTotalArea()
    {
        double total = 0;
        foreach (Region r in Regions) total += r.Area;
        Console.WriteLine("загальна площа: " + total + " кв. км");
    }

    public void printCenters()
    {
        Console.WriteLine("обласні центри:");
        foreach (Region r in Regions) Console.WriteLine("- " + r.Center);
    }
}

class Program
{
    static void Main()
    {
        City kyiv = new City("Київ", 3600000);
        City bilaTserkva = new City("Біла Церква", 208000);
        City lviv = new City("Львів", 720000);
        City odessa = new City("Одеса", 1010000);

        District d1 = new District("Білоцерківський", new City[] { bilaTserkva });
        District d2 = new District("Київський", new City[] { kyiv });
        District d3 = new District("Львівський", new City[] { lviv });
        District d4 = new District("Одеський", new City[] { odessa });

        Region r1 = new Region("Київська", 28131, kyiv, new District[] { d1, d2 });
        Region r2 = new Region("Львівська", 21833, lviv, new District[] { d3 });
        Region r3 = new Region("Одеська", 33314, odessa, new District[] { d4 });

        Country country = new Country("Україна", kyiv, new Region[] { r1, r2, r3 });

        country.printCapital();
        country.printRegionsCount();
        country.printTotalArea();
        country.printCenters();

        Console.ReadLine();
    }
}