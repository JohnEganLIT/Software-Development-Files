using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class Car : Vehicle
    {
        public int NumDoors { get; set; }
        public int NumSeats { get; set; }

        public Car(){}

        public Car(string make, string model, int numOwners, double engineSize, string vinNum, string regNum, double mileage, string description, double price, string bodyType, int numDoors, int numSeats) 
            : base(make, model, numOwners, engineSize, vinNum, regNum, mileage, description, price, bodyType)
        {

        }

        public override void PrintDetails()
        {
            Console.WriteLine(Make);
            Console.WriteLine(Model);
            Console.WriteLine(NumOwners);
            Console.WriteLine(VinNum);
            Console.WriteLine(RegNum);
            Console.WriteLine(Mileage);
            Console.WriteLine(Description);
            Console.WriteLine(Price);
        }
    }
}
