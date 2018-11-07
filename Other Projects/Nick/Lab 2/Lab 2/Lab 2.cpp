#include "pch.h"
#include <iostream>

#include "Car.h"
#include "Motorbike.h"
#include "Boat.h"

int main()
{
	Car myCar;
	myCar.setMake("Honda");
	myCar.setModel("Accord");
	myCar.setPrice(2000.00);
    myCar.setYear(2010);
	myCar.setNumDoors(4);

	cout << "Car" << endl;
	cout << "------------" << endl;
	cout << "Make: " << myCar.getMake() << "\nModel: " << myCar.getModel() << "\nPrice: " << myCar.getPrice() << "\nYear: " << myCar.getYear() << "\nNumber of Doors:" << myCar.getNumDoors() << endl;
	cout << "\n" << endl;

	Motorbike myMotorbike;
	myMotorbike.setMake("Yamaha");
	myMotorbike.setModel("Dragster");
	myMotorbike.setPrice(750.00);
	myMotorbike.setYear(2003);
	myMotorbike.setNumWheels(2);

	cout << "Motorbike" << endl;
	cout << "------------" << endl;
	cout << "Make: " << myMotorbike.getMake() << "\nModel: " << myMotorbike.getModel() << "\nPrice: " << myMotorbike.getPrice() << "\nYear: " << myMotorbike.getYear() << "\nNumber of Wheels: " << myMotorbike.getNumWheels() << endl;
	cout << "\n" << endl;

	Boat myBoat;
	myBoat.setMake("Bertram");
	myBoat.setModel("Flybridge Cruiser");
	myBoat.setPrice(150000.00);
	myBoat.setYear(1979);
	myBoat.setDisplacementRatio(300);

	cout << "Boat" << endl;
	cout << "------------" << endl;
	cout << "Make: " << myBoat.getMake() << "\nModel: " << myBoat.getModel() << "\nPrice: " << myBoat.getPrice() << "\nYear: " << myBoat.getYear() << "\nDisplacement Ratio: " << myBoat.getDisplacementRatio() << endl;
}
