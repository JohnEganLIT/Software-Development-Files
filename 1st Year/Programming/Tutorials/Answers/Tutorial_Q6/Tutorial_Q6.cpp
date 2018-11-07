// Tutorial_Q6.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	
	int sales[5][4];
	int SalesNum, modelNumber, NumCarsSold = 0;
	char response;
	ifstream infile("Sales.dat");

	for (int row = 0; row < 5; row++ ) 
		for ( int col = 0; col < 4; col++ )
			infile >> sales[row][col];

	

	do
	{

		cout << "Please enter the salesperson's number: (enter number between 1 and 5): ";
		cin >> SalesNum;

		cout << "Please enter the car model number: (enter number between 1 and 4): ";
		cin >> modelNumber;

		if ( ((SalesNum == -1) || (modelNumber == -1)) )
			return 0;
		else
		{
			cout << "Please enter the number of cars sold: ";
			cin >> NumCarsSold;

			sales[SalesNum-1][modelNumber-1] += NumCarsSold;
		}

		cout << "Do you wish to exit (Y/N)? ";
		cin >> response;

	} while (response == 'N');

	ofstream outfile("Output.dat");

	for (int row = 0; row < 5; row++ )   
	{
		for ( int col = 0; col < 4; col++ )
		{
			outfile << sales[row][col] << "  ";
		}
		outfile << endl;
	}
	
	return 0;
}

