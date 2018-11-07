#include "pch.h"
#include "Car.h"


Car::Car()
{
}


Car::~Car()
{
}

void Car::setNumDoors(int NumDoors)
{
	numDoors = NumDoors;
}

int Car::getNumDoors()
{
	return numDoors;
}
