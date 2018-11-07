#include "pch.h"
#include "Vehicle.h"


Vehicle::Vehicle()
{
}


Vehicle::~Vehicle()
{
}

string Vehicle::getMake()
{
	return make;
}

string Vehicle::getModel()
{
	return model;
}

int Vehicle::getYear()
{
	return year;
}

double Vehicle::getPrice()
{
	return price;
}

void Vehicle::setMake(string Make)
{
	make = Make;
}

void Vehicle::setModel(string Model)
{
	model = Model;
}

void Vehicle::setYear(int Year)
{
	year = Year;
}

void Vehicle::setPrice(double Price)
{
	price = Price;
}

