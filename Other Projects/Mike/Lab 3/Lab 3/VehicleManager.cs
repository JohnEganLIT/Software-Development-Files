using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class VehicleManager
    {
        List<Vehicle> vehicleList = new List<Vehicle>();

        public VehicleManager()
        {
            Console.WriteLine("Vehicle Management System");

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. View all vehicles");
                Console.WriteLine("3. View single vehicle");
                Console.WriteLine("4. Exit Program");

                Console.Write("Enter Option: ");
                int option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddVehicle();
                        break;
                    case 2:
                        ViewAllVehicles();
                        break;
                    case 3:
                        ViewVehicle();
                        break;
                    case 4:
                        Console.WriteLine("Goodbye :)");
                        break;
                    default:
                        Console.WriteLine("Incorrect Option!");
                        break;
                }
            }
        }

        void AddVehicle()
        {
            string make, model, vinNum, regNum, description;
            int numOwners;
            double engineSize, mileage, price;

            int vehicleType;

            Console.WriteLine("Would you like to add a\n1. Car \n2. Motorbike");
            vehicleType = Int32.Parse(Console.ReadLine());

            Console.Write("Enter Make: ");
            make = Console.ReadLine().ToString();

            Console.Write("Enter Model: ");
            model = Console.ReadLine().ToString();

            Console.Write("Enter number of previous owners: ");
            int.TryParse(Console.ReadLine(), out numOwners);

            Console.Write("Enter engine size: ");
            engineSize = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter VIN number: ");
            vinNum = Console.ReadLine().ToString();

            Console.Write("Enter registration number: ");
            regNum = Console.ReadLine().ToString();

            Console.Write("Enter Mileage: ");
            mileage = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter description: ");
            description = Console.ReadLine().ToString();

            Console.Write("Enter price: ");
            price = Convert.ToDouble(Console.ReadLine());

            if(vehicleType == 1)
            {
                AddCar(make, model, numOwners, engineSize, vinNum, regNum, mileage, description, price);
            }
            
            else
            {
                AddMotorbike(make, model, numOwners, engineSize, vinNum, regNum, mileage, description, price);
            }
        }

        void AddMotorbike(string make, string model, int numOwners, double engineSize, string vinNum, string regNum, double mileage, string description, double price)
        {
            int numWheels;
            string bodyType = ""; 

            Console.Write("Enter number of wheels: ");
            numWheels = Int32.Parse(Console.ReadLine());

            Console.WriteLine("1. Cruiser");
            Console.WriteLine("2. Sport");
            Console.WriteLine("3. Touring");
            Console.WriteLine("4. Sport Touring");
            Console.WriteLine("5. Dual Sport");
            Console.Write("Enter body type: ");

            int option = Int32.Parse(Console.ReadLine());
            
            switch(option)
            {
                case 1:
                    bodyType = "Cruiser";
                    break;
                case 2:
                    bodyType = "Sport";
                    break;
                case 3:
                    bodyType = "Touring";
                    break;
                case 4:
                    bodyType = "Sport Touring";
                    break;
                case 5:
                    bodyType = "Dual Sport";
                    break;
                default:
                    Console.WriteLine("Incorrect Option!");
                    break;
            }

            MotorBike newBike = new MotorBike(make, model, numOwners, engineSize, vinNum, regNum, mileage, description, price, bodyType, numWheels);

            vehicleList.Add(newBike);
        }

        void AddCar(string make, string model, int numOwners, double engineSize, string vinNum, string regNum, double mileage, string description, double price)
        {
            int numDoors, numSeats;
            string bodyType = "";

            Console.Write("Enter number of doors: ");
            numDoors = Int32.Parse(Console.ReadLine());

            Console.Write("Enter number of seats: ");
            numSeats = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("1. Hatchback");
            Console.WriteLine("2. Sedan");
            Console.WriteLine("3. SUV");
            Console.WriteLine("4. Coupe");
            Console.WriteLine("5. Covertible");
            Console.WriteLine("6. Van");
            Console.WriteLine("7. Jeep");
            Console.Write("Enter body type: ");

            int option = Int32.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    bodyType = "Hatchback";
                    break;
                case 2:
                    bodyType = "Sedan";
                    break;
                case 3:
                    bodyType = "SUV";
                    break;
                case 4:
                    bodyType = "Coupe";
                    break;
                case 5:
                    bodyType = "Convertible";
                    break;
                case 6:
                    bodyType = "Van";
                    break;
                case 7:
                    bodyType = "Jeep";
                    break;
                default:
                    Console.WriteLine("Incorrect Option!");
                    break;
            }

            Car newCar = new Car(make, model, numOwners, engineSize, vinNum, regNum, mileage, description, price, bodyType, numDoors, numSeats);
            vehicleList.Add(newCar);
        }

        void ViewAllVehicles()
        {
            Console.WriteLine("Make -- Model -- Reg Number -- Body Type -- Engine Size -- Mileage -- Price");
            foreach(Vehicle o in vehicleList)
            {
                Console.WriteLine(o.Make + "  " + o.Model + "  " + o.RegNum + "  " + o.BodyType + "  " + o.EngineSize + "  " + o.Mileage + " " + o.Price);
            }
        }

        void ViewVehicle()
        {
            string regNum;

            Console.WriteLine("Enter registration number: ");
            regNum = Console.ReadLine().ToString();

            foreach(Vehicle o in vehicleList)
            {
                if(o.RegNum == regNum)
                {
                    Console.WriteLine("Make -- Model -- Reg Number -- Body Type -- Engine Size -- Mileage -- Price");
                    Console.WriteLine(o.Make + "  " + o.Model + "  " + o.RegNum + "  " + o.BodyType + "  " + o.EngineSize + "  " + o.Mileage + " " + o.Price);
                }

                else
                {
                    Console.WriteLine("Vehicle not found!");
                }
            }
        }
    }
}
