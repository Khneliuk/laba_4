using System;
namespace laba_4;
public class task1
{
    public class City
	{
		public string Name;
		public int Population;
		public City(string name, int population)
		{
            this.Name = name;
            this.Population = population;
            Console.WriteLine("створено місто: " + name);
        }
		public override string ToString()
        {
            return "місто " + Name + " (населення: " + Population + ")";
        }
        public override bool Equals(object? obj)
        {
            City? other = obj as City;
            return other != null && this.Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
	}
	public class District
    {
        public string Name;
        public District(string name)
        {
            this.Name = name;
            Console.WriteLine("створено район: " + name);
        }
    }
	public class Region
    {
        public string Name;
        public double Area;
        public City Center; 
        public Region(string name, double area, City center)
        {
            this.Name = name;
            this.Area = area;
            this.Center = center;
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
        public void printCapital()
        {
            Console.WriteLine("столиця: " + Capital.Name);
        }
        public void printRegionsCount()
        {
            Console.WriteLine("кількість областей: " + Regions.Length);
        }
        public void printTotalArea()
        {
            double total = 0;
            foreach (Region r in Regions) total += r.Area;
            Console.WriteLine("загальна площа: " + total + " кв. км");
        }
        public void printCenters()
        {
            Console.WriteLine("обласні центри:");
            foreach (Region r in Regions)
            {
                Console.WriteLine("- " + r.Center.Name);
            }
        }
	}
}
class Program
    {
        static void Main()
        {
            City kyiv = new City("Київ", 3600000);
            City lviv = new City("Львів", 1000000);
            City odessa = new City("Одеса", 1000000);
            
            Region r1 = new Region("Київська", 28131, kyiv);
            Region r2 = new Region("Львівська", 21833, lviv);
            Region r3 = new Region("Одеська", 33314, odessa);

            Country сountry = new Country("Україна", kyiv, new Region[] { r1, r2, r3 });

            сountry.printCapital();
            сountry.printRegionsCount();
            сountry.printTotalArea();
            сountry.printCenters();

            Console.ReadLine();
        }
    }