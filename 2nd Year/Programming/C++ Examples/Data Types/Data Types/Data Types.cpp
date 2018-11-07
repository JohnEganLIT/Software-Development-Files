// Data Types.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	cout << "Int is " << sizeof(int) << " bytes. Whole numbers between -2,147,483,648 and 2,147,483,647." << endl;
	cout << "Char is " << sizeof(char) << " bytes. Can hold 1 character." << endl;
	cout << "String is " << sizeof(string) << " bytes. Can hold up to 4294967295. Size changes with length of string" << endl;
	cout << "double is " << sizeof(double) << " bytes." << endl;
	cout << "Float is " << sizeof(long int) << " bytes." << endl;
	cout << "long double is " << sizeof(long double) << " bytes." << endl;
	cout << "long double is " << sizeof(long double) << " bytes." << endl;
	cout << "Unsigned Int is " << sizeof(unsigned int) << " bytes." << endl;
	
}

