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
}