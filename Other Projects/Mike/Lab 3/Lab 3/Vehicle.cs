using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public abstract class Vehicle
    {
        public readonly string Make;
        public readonly string Model;
        public int NumOwners { get; set; }
        public double EngineSize { get; set; }
        public string VinNum { get; set; }
        public string RegNum { get; set; }
        public double Mileage { get; set; } = 0;
        public string Description { get; set; }
        public double Price { get; set; }
        public string BodyType { get; set; }

        public Vehicle() { }

        public Vehicle(string make, string model, int numOwners, double engineSize, string vinNum, string regNum, double mileage, string description, double price, string bodyType)
        {
            Make = make;
            Model = model;
            NumOwners = numOwners;
            EngineSize = engineSize;
            VinNum = vinNum;
            RegNum = regNum;
            Mileage = mileage;
            Description = description;
            Price = price;
            BodyType = bodyType;
        }
        ~Vehicle(){}

        public abstract void PrintDetails();
    }
}
