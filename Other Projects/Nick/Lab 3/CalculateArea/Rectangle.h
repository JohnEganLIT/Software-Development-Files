#pragma once
#include "Shape.h"

class Rectangle : public Shape
{
public:
	Rectangle();
	~Rectangle();

	double getArea()
	{
		return width*height;
	}
};

