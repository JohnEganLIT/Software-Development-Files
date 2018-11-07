using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Make = "BMW";
            myCar.Model = "745li";
            myCar.Colour = "Black";
            myCar.Year = 2005;

            Truck myTruck = new Truck();
            myTruck.Make = "Ford";
            myTruck.Model = "F950";
            myTruck.Colour = "Red";
            myTruck.Year = 2006;
            myTruck.TowingCapacity = 1200;

            PrintVehicleDetails(myCar);
            PrintVehicleDetails(myTruck);

            Console.ReadLine();
        }

        private static void PrintVehicleDetails(Vehicle vehicle)
        {
            Console.WriteLine($"Here are the vehicle's details: {vehicle.FormatMe()}");
        }
    }
    
    /// <summary>
    /// Abstract class. Represents a generic vehicle.
    /// </summary>
    abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public int Year { get; set; }

        /// <summary>
        /// Formats information about this vehicle and outputs to console.
        /// </summary>
        public abstract string FormatMe();
    }

    /// <summary>
    /// Represents a car.
    /// </summary>
    sealed class Car : Vehicle //Sealed is the opposite of abstract. No class can derive from this class.
    {    
        public override string FormatMe() 
        {
            return String.Format("{0} - {1} - {2} - {3}", this.Make, this.Model, this.Colour, this.Year);
        }
    }

    /// <summary>
    /// Represents a truck.
    /// </summary>
    sealed class Truck : Vehicle
    {
        public int TowingCapacity { get; set; }

        public override string FormatMe()
        {
            return String.Format("{0} - {1} - {2} Towing units", this.Make, this.Model, this.TowingCapacity);
        }
    }
}
