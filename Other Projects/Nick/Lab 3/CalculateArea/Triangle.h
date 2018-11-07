#pragma once
#include "Shape.h"
class Triangle : public Shape
{
public:
	Triangle();
	~Triangle();

	double getArea() override
	{
		return width*height/2;
	}
};

