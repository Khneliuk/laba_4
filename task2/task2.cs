using System;
using System.Collections.Generic;
namespace laba_4;
public class task2
{
    public class Trip
    {
        private readonly string code; 
        private double distance;
        private double basePrice;
        public static int TotalTripsCount = 0;
        public Trip(string code, double distance, double basePrice)
        {
            this.code = code;
            this.distance = distance;
            this.basePrice = basePrice;
            Trip.TotalTripsCount++; 
        }
        public double BasePrice
        {
            get { return this.basePrice; }
        }
        public virtual string GetInfo()
        {
            return "код: " + this.code + ", відстань: " + this.distance + " км, ціна: " + this.basePrice + " грн";
        }
        public bool IsLongTrip()
        {
            return this.distance > 50;
        }
    }
    public class CityTrip : Trip
    {
        private string district;

        public CityTrip(string code, double distance, double basePrice, string district) 
            : base(code, distance, basePrice)
        {
            this.district = district;
        }
        public override string GetInfo()
        {
            return base.GetInfo() + ", район: " + this.district;
        }
    }
    public class IntercityTrip : Trip
    {
        private string destinationCity;

        public IntercityTrip(string code, double distance, double basePrice, string destinationCity) 
            : base(code, distance, basePrice)
        {
            this.destinationCity = destinationCity;
        }
        public override string GetInfo()
        {
            return base.GetInfo() + ", місто призначення: " + this.destinationCity;
        }
    }
public class TaxiService
    {
        private List<Trip> allTrips = new List<Trip>();

        public void AddTrip(Trip trip)
        {
            allTrips.Add(trip);
            Console.WriteLine($"додано поїздку {trip.Code}");
        }

        public void RemoveTrip(string code)
        {
            Trip tripToRemove = allTrips.Find(t => t.Code == code);
            if (tripToRemove != null)
            {
                allTrips.Remove(tripToRemove);
                Trip.TotalTripsCount--; 
                Console.WriteLine($"поїздку {code} видалено");
            }
            else
            {
                Console.WriteLine($"поїздку з кодом {code} не знайдено");
            }
        }

        public void PrintReport()
        {
            Console.WriteLine("\nсервіс таксі");
            double totalPrice = 0;
            int longCount = 0;

            foreach (var trip in allTrips)
            {
                Console.WriteLine(trip.GetInfo());
                totalPrice += trip.BasePrice;
                if (trip.IsLongTrip()) longCount++;
            }

            Console.WriteLine("загальна кількість поїздок: " + Trip.TotalTripsCount);
            Console.WriteLine("загальна сума за всі поїздки: " + totalPrice + " грн");
            Console.WriteLine("кількість довгих поїздок: " + longTripsCount);
        }
    class Program
    {
        static void Main()
        {
            TaxiService service = new TaxiService();

            allTrips.Add(new CityTrip("C-101", 15.0, 180, "Печерський"));
            allTrips.Add(new IntercityTrip("I-202", 480.5, 3500, "Одеса"));
            allTrips.Add(new CityTrip("C-103", 62.0, 750, "Оболонський"));

            service.PrintReport();
            service.RemoveTrip("C-101");
            service.PrintReport();
            Console.ReadLine();
        }
    }
}