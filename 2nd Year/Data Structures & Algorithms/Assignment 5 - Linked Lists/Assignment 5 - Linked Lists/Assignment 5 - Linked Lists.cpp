#include "stdafx.h"
#include "list.h"

void addNode();
void print();
//void menu();

int main()
{
	cout << "1. Add Node" << endl;
	cout << "2. Print" << endl;
	cout << "Enter Option: ";

	int option;
	cin >> option;

	switch (option)
	{
		case 1:
			addNode();
			break;
		case 2:
			print();
			break;
		default:
			break;
	}	
}

void addNode()
{
	string data;

	cout << "Enter String: ";
	cin >> data;

	list listObj;
	listObj.addNode(data);

	system("PAUSE");
	main();
}

void print()
{
	list printObj;
	printObj.print();

	system("PAUSE");
	main();
}

/*
void menu()
{
	system("PAUSE");
	system("CLS");
	main();
}
*/
