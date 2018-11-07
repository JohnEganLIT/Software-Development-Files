// Tutorial_Q3.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	
	double carValue, cost;
	int age, points;
	double ageFactor, pointsFactor, valueFactor = 10.0;;

	cout << "Enter value of car, age and number of points :";
	cin >> carValue >> age >> points;   

	if ( age < 18  ||  points >= 9 )   
	{
		cout << "Ineligible\n";
		if ( age < 18 )
			cout << "Under 18 years of age\n";
		else
			cout << "9 or more points\n";   
	}
	else
	{
		if (age <= 20 )   
			ageFactor = 2.0;
		else if ( age <= 25 )
			ageFactor = 1.5;
		else
			ageFactor = 1.0;

		switch ( points )   
		{
		case 5:
			pointsFactor = 1.1;
			break;
		case 6:
			pointsFactor = 1.2;
			break;
		case 7:
			pointsFactor = 1.4;
			break;
		case 8:
			pointsFactor = 1.7;
			break;
		default:
			pointsFactor = 1.0;
		}

		cost = ( 250 + ((double)carValue/1000) * valueFactor )  * ageFactor  * pointsFactor;

		cout << "Cost of insurance is " << cost << endl;   
	}

	
	return 0;
}

