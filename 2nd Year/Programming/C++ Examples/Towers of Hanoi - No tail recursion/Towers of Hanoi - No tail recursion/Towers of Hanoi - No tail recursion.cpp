#include "stdafx.h"

using namespace std;

void hanoi(int n, int start, int temp, int finish)
{
	int swap;

	while (n > 1)
	{
		
		hanoi(n - 1, start, finish, temp);

		cout << "Move top disk from pole " << start << " to pole " << finish << endl;

		n--;

		swap = start;
		start = temp;
		temp = swap;
	
	}

	if (n == 1)
		cout << "Move top disk from pole " << start << " to pole " << finish << endl;
	
}

int main()
{
	int disks;
	cout << "Enter number of disks: ";
	cin >> disks;

	cout << "Towers of Hanoi: Solving a problem of size " << disks << endl;

	hanoi(disks, 1, 2, 3);
}

