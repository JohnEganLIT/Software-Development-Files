// Tutorial_Q2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{

	string knums[20];
	int marks[20];
	
	ifstream infile("Marks.dat");
	for ( int i = 0; i< 20; i++ )
	{
		infile >> knums[i] >> marks[i];
	}
	infile.close();

	char grades[20];
	for ( int i = 0; i < 20; i++ )
	{
		if ( marks[i] < 40 )
			grades[i] = 'F';
		else if ( marks[i] < 50 )
			grades[i] = 'E';
		else if ( marks[i] < 60 )
			grades[i] = 'D';
		else if ( marks[i] < 70 )
			grades[i] = 'C';
		else if ( marks[i] < 85 )
			grades[i] = 'B';
		else 
			grades[i] = 'A';
	}

	ofstream outfile("Grades.dat");
	for ( int i = 0; i < 20; i++ )
	{
		outfile << knums[i] << "  " << grades[i] << endl;
	}
	outfile.close();


	return 0;
}

