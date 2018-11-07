#include "stdafx.h"

using namespace std;

void hanoi(int n, int start, int temp, int finish)
{
	if (n == 1)
		cout << "Move top disk from pole" << start << " to top of pole " << finish << endl;
	
	else
	{
		hanoi(n - 1, start, finish, temp);

		cout << "Move top disk from pole" << start << " to top of pole " << finish << endl;

		hanoi(n - 1, temp, start, finish);
	}
}

int main()
{
	int disks;

	cout << "\n Enter the number of disks: ";
	cin >> disks;

	cout << "\n Towers of Hanoi: Solving a problem of size " << disks << endl;

	hanoi(disks, 1, 2, 3);
}

