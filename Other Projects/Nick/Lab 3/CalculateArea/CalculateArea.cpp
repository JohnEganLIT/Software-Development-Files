#include "stdafx.h"
#include "Shape.h"
#include "Triangle.h"
#include "Circle.h"
#include "Square.h"
#include "Rectangle.h"

int main()
{
	Square sq;

	sq.setWidth(5);
	sq.setHeight(7);


	cout << "Total area of square: " << sq.getArea() << endl;

	Triangle tr;
	tr.setHeight(7);
	tr.setWidth(2);

	cout << "Total area of triangle: " << tr.getArea() << endl;

	Rectangle rec;
	rec.setHeight(4);
	rec.setWidth(2);

	cout << "Total area of rectangle: " << rec.getArea() << endl;


	Circle ci;
	ci.setWidth(10);

	cout << "Total area of circle is: " << ci.getArea() << endl;

	return 0;
}

