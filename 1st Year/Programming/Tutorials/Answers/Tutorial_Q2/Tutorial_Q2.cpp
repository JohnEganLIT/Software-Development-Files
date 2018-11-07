// Tutorial_Q2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int month, numDays;
	double discountRate, seasonalRate, cost;
	cout << "Enter hire month and number of days";
	cin >> month >> numDays;

	switch ( month )
	{
	case 3:
	case 4:
		seasonalRate = 100;
		break;
	case 5:
	case 6:
	case 9:
	case 10:
		seasonalRate = 250;
		break;
	case 7:
	case 8:
		seasonalRate = 400;
		break;
	}

	if ( numDays <= 15 )
		discountRate = 0;
	else if ( numDays <= 30 )
		discountRate = 5;
	else if ( numDays <= 60 )
		discountRate = 10;
	else
		discountRate = 15;


	cost = numDays * seasonalRate * ( 1 - discountRate / 100 );
	cout << "Cost of hire is " << cost << endl;
	return 0;
}

