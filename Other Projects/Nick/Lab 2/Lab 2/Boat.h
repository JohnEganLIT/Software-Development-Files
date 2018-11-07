#pragma once
#include "Vehicle.h"
class Boat :
	public Vehicle
{
	public:
		Boat();
		~Boat();

		void setDisplacementRatio(int);

		int getDisplacementRatio();

	private:
		int displacementRatio;
};

