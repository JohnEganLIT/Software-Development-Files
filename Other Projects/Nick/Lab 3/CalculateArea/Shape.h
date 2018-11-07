#pragma once
class Shape
{
	public:
	Shape();
	~Shape();

	void setWidth(double);
	void setHeight(double);
	virtual double getArea();

	protected:
	double width;
	double height;
};



