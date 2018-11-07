#include "stdafx.h"
#include "Animal.h"

Animal::Animal(string Name, int Age, float Weight)
{
	name = Name;
	age = Age;
	weight = Weight;
}

Animal::~Animal()
{
}

string Animal::getName()
{
	return name;
}

int Animal::getAge()
{
	return age;
}

float Animal::getWeight()
{
	return weight;
}
