using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class MotorBike : Vehicle
    {
        public int NumWheels { get; set; }
        public string bodyType { get; set; }
        public int numWheels { get; set; }

        public MotorBike() { }

        public MotorBike(string make, string model, int numOwners, double engineSize, string vinNum, string regNum, double mileage, string description, double price, string bodyType, int numWheels)
            : base(make, model, numOwners, engineSize, vinNum, regNum, mileage, description, price, bodyType)
        {
            NumWheels = numWheels;
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
            Console.WriteLine(bodyType);
            Console.WriteLine(numWheels);
        }
    }
}
