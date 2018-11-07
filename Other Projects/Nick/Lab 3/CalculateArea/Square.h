#pragma once
#include "Shape.h"
#include <iostream>
using namespace std;
class Square : public Shape
{
public:
	Square();
	~Square();

	double getArea() override
	{
		return width*height;
	}
};
