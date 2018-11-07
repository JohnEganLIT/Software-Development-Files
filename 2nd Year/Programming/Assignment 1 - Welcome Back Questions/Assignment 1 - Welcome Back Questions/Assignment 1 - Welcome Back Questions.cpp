#include "stdafx.h"

using namespace std;

void question1();
void question2();
void question3();
void question4();
void question5();

void main()
{
	cout << "1: Question 1" << endl;
	cout << "2: Question 2" << endl;
	cout << "3: Question 3" << endl;
	cout << "4: Question 4" << endl;
	cout << "5: Question 5\n" << endl;

	cout << "Enter Option: ";

	int option;

	cin >> option;

	switch (option)
	{
	case 1:
		question1();
		break;
	case 2:
		question2();
		break;
	case 3:
		question3();
		break;
	case 4:
		question4();
		break;
	case 5:
		question5();
		break;
	default:
		cout << "Incorrect Option\n" << endl;
		main();
	}
}

void question1()
{
	int number, counter = 0;

	cout << "\nEnter a list of numbers: (-1 to end)" << endl;

	cin >> number;

	while (number != -1)
	{
		if (number % 2 == 0)
		{
			counter++;
		}
		cin >> number;
	}

	cout << "\nYou entered " << counter << " even numbers.\n" << endl;

	main();
}

void question2()
{
	string test = "Happy days are here again";

	cout << "\nThere is a letter A at positions ";

	for (int x = 0; x < test.length(); x++)
	{
		if (test[x] == 'a')
		{
			cout << x + 1 << " ";
		}
	}

	cout << "\n" << endl;
	main();
}

void question3()
{
	int numRows;

	cout << "\nEnter number of rows: ";
	cin >> numRows;

	cout << endl;

	for (int i = 0; i < numRows; i++)
	{
		int value = 0;
		int col = i;

		while (col >= 0)
		{
			col--;
			value += 2;
			cout << value << " ";
		}
		cout << " " << endl;
	}
	cout << endl;
	main();
}

void question4()
{
	cout << "Enter 15 Numbers\n" << endl;

	int numbers[15];

	for (int x = 0; x < 15; x++)
	{
		cout << "Enter NO." << x + 1 << ": ";
		cin >> numbers[x];
	}

	cout << "\nThese numbers are greater than " << numbers[14] << ": ";

	for (int x = 0; x < 15; x++)
	{
		if (numbers[x] > numbers[14])
		{
			cout << numbers[x] << " ";
		}
	}
	cout << "\n";
}

void question5()
{
	int randomNumber[1000], frequency[50];

	for (int y = 0; y < 50; y++)
	{
		frequency[y] = 0;
	}

	for (int x = 0; x < 1000; x++)
	{
		randomNumber[x] = rand() % 50;

		for (int y = 1; y < 50; y++)
		{
			if (randomNumber[x] == y)
			{
				frequency[y]++;
			}
		}
	}

	for (int y = 1; y < 50; y++)
	{
		cout << y << " shows up " << frequency[y] << " times." << endl;
	}

	cout << endl;
	main();
}






