// Tutorial_Q5.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
using namespace std;


int _tmain(int argc, _TCHAR* argv[])
{
	int grid1[50][20], grid2[50][20];
	int differenceCounter = 0;
	double percentDifference;

	ifstream infile1("Picture1.dat");
	for ( int row = 0; row < 50; row++)
	{
		for (int col = 0; col < 20; col++ )
		{
			infile1 >> grid1[row][col];
		}
	}
	infile1.close();

	ifstream infile2("Picture2.dat");
	for ( int row = 0; row < 50; row++)
	{
		for (int col = 0; col < 20; col++ )
		{
			infile2 >> grid2[row][col];
		}
	}
	infile1.close();

	for ( int row = 0; row < 50; row++)
	{
		for (int col = 0; col < 20; col++ )
		{
			if ( grid1[row][col] != grid2[row][col] )
				differenceCounter ++;
		}
	}

	percentDifference = double(differenceCounter) / 1000 * 100;

	if ( percentDifference <= 5 )
		cout << percentDifference << "Images are identical\n";
	else
		cout << percentDifference << "Images are not identical\n";


	return 0;
}

