// Practice.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>
using namespace std;

typedef struct
{
	int day;
	int month;
	int year;
} Date;

struct Person
{
	string name;
	int age;
	Date date;
};

typedef int sexyDataType;
int main()
{
	Person person1;

	person1.name = "Colin";
	person1.age = 21;
	person1.date.day = 24;
	person1.date.month = 8;
	person1.date.year = 2016;

	cout << person1.name << endl;
	cout << person1.age << endl;
	cout << person1.date.day << "/";
	cout << person1.date.month << "/";
	cout << person1.date.year << endl;
}
