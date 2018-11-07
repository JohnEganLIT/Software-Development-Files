// Pointers.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

void function1(int* p);

int main()
{
	int a = 10;
	cout << "Value of A: " << a << endl;

	int* p = &a;
	cout << "Pointer P points to int A which is in this memory location: " << p << endl;

	int** q = &p;
	cout << "Pointer to pointer Q points to pointer P which is in this memory location: " << q << endl;

	function1(p);

	cout << "Value of A is now " << a << " after dereferenced p was changed to 5" << endl;
}

void function1(int* p)
{
	*p = 5;

	return;
}

