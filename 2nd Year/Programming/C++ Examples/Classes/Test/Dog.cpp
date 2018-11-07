#include "stdafx.h"
#include "Dog.h"
#include "Animal.h"

Dog::Dog(string Name, int Age, float Weight, string Breed) : Animal(Name, Age, Weight)
{
	breed = Breed;
}

Dog::~Dog()
{
}

string Dog::getBreed()
{
	return breed;
}

void Dog::displayAll()
{
	cout << name << " " << age << " " << weight << " " << breed << endl;
}
