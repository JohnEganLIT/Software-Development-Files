// Function Templates.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

template <typename T>
void display(T value)
{
	cout << value << endl;
}

int main()
{
	display(25);
	display(45.23);
	display("Hello");
	display('D');
}





