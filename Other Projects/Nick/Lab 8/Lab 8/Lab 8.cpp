#include "pch.h"
#include <iostream>
#include <vector>

using namespace std;

void a();
void b();
void c();

class DivideByZeroException : exception
{
	string msg = "\nDivide By Zero Error!";

	public:
	const char* what()
	{
		return msg.c_str();
	}
};

int main()
{
	bool exit = false;
	while (!exit)
	{
		cout << endl;
		cout << "1. Question A" << endl;
		cout << "2. Question B" << endl;
		cout << "3. Question C" << endl;
		cout << "4. Exit Application" << endl;
		cout << "Enter Option: ";

		int option;
		cin >> option;

		switch (option)
		{
		case 1:
			a();
			break;
		case 2:
			b();
			break;
		case 3:
			c();
			break;
		case 4:
			exit = true;
			break;
		default:
			cout << "Incorrect Option" << endl;
			break;
		}
	}
}

void a()
{
	vector<int> v = { 7, 5, 16, 8, 3 };

	try
	{
		cout << v.at(10) << endl;
	}
	catch (exception e)
	{
		cout << "\nIndex out of bounds" << endl;
	}
}

void b()
{
	double x, y;
	cout << "\nEnter Two Numbers to divide: " << endl;

	cout << "Number 1: ";
	cin >> x;

	cout << "Number 2: ";
	cin >> y;

	try
	{
		if (x == 0 || y == 0)
		{
			throw exception("\nDivide By Zero Error!");
		}

		cout << "Result: " << x / y << endl;
	}
	catch (exception e)
	{
		cout << e.what() << endl;
	}
}

void c()
{
	double x, y;
	cout << "\nEnter Two Numbers to divide: " << endl;

	cout << "Number 1: ";
	cin >> x;

	cout << "Number 2: ";
	cin >> y;

	try
	{
		cout << "Result: " << x / y << endl;

		if (x == 0 || y == 0)
		{
			throw DivideByZeroException();
		}
	}
	catch (DivideByZeroException e)
	{
		cout << e.what() << endl;
	}
}
