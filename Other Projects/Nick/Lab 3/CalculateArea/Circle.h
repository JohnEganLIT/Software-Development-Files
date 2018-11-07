#pragma once
#include "Shape.h"
class Circle : public Shape
{
public:
	Circle();
	~Circle();
	
	double getArea() override
	{
		return 3.14*width/2*width/2;
	}
};

