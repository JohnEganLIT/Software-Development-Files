#pragma once
#include "Vehicle.h"

class Car : public Vehicle
{
	public:
		Car();
		~Car();

		int getNumDoors();
		void setNumDoors(int);

	private:
		int numDoors;
};

