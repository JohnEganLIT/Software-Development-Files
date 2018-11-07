#pragma once
#include "pch.h"

class Vehicle
{
	public:
		Vehicle();
		~Vehicle();

		string getMake();
		string getModel();
		int getYear();
		double getPrice();

		void setMake(string);
		void setModel(string);
		void setYear(int);
		void setPrice(double);

	private:
		string make;
		string model;
		int year;
		double price;
};

