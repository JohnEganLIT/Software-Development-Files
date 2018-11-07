#include "stdafx.h"
#include "iostream"

using namespace std;

class Shape
{
protected:
	int height, width;

public:
	void getInput()
	{
		cout << "Enter Height: ";
		cin >> height;

		cout << "Enter Width:";
		cin >> width;
	}

	virtual int area() = 0;
};

class Rectangle : public Shape
{
public:
	int area()
	{
		cout << "Triangle Area" << endl;
		return height * width;
	}
};

class Triangle : public Shape
{
public:
	int area()
	{
		cout << "Triangle Area" << endl;
		return height * width / 2;
	}
};

int main()
{
	Rectangle rect;
	rect.getInput();
	cout << rect.area() << endl;

	Triangle tri;
	tri.getInput();
	cout << tri.area() << endl;

}

