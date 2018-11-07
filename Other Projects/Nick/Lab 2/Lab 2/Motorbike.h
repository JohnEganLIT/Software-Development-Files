#pragma once
#include "Vehicle.h"
class Motorbike : public Vehicle
{
	public:
		Motorbike();
		~Motorbike();

		int getNumWheels();
		void setNumWheels(int);

	private:
		int numWheels;
};

