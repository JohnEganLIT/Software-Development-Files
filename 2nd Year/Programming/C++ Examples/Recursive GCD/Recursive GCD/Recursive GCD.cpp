#include "stdafx.h"
#include <iostream>

using namespace std;

int gcd(int m, int n)
{
	if (m == n)
		return m;
	else if (m > n)
		return gcd(m - n, n);
	else
		return gcd(m, n - m);
}

int main()
{
	int a, b;

	cout << "Enter first number: ";
	cin >> a;

	cout << "Enter the second number: ";
	cin >> b;

	cout << "The greatest common divisor of " << a << " and " << b << " is " << gcd(a, b) << "." << endl;
}

