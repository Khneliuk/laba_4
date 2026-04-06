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
    
}