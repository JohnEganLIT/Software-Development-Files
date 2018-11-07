#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

struct student{
	string kNum;
	string name;
};

int main()
{
	student students[5];

	ifstream infile("students.txt");

	while (!infile.eof())
	{	
		for (int i = 0; i < 5; i++)
		{
			infile >> students[i].kNum >> students[i].name;
		}
	}

	cout << "The Class List Is:\n" << endl;
	cout << "KNUM\t\tNAME\n";
	cout << "---------------------" << endl;

	for (int i = 0; i < 5; i++)
	{
		cout << students[i].kNum << "\t\t"<< students[i].name << endl;
	}

	infile.close();
}
