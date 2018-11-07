// Test.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Animal.h"
#include "Dog.h"

int main()
{
	Dog dog1("Jimmy", 4, 14.6, "Rottweiller");

	dog1.displayAll();

	Dog* dog3 = new Dog("Jimmy", 4, 14.6, "Rottweiller");

	dog3->displayAll();
}

