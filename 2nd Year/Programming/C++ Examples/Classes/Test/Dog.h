#pragma once
#include "Animal.h"

class Dog : public Animal
{
	public:
		Dog(string, int, float, string);
		~Dog();

		string getBreed();

		void displayAll();
	
	private:
		string breed;
};

