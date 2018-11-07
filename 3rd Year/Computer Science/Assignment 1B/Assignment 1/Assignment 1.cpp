#include "stdafx.h"
#include "TreeType.h"
#include <iostream>
#include <string>

using namespace std;

template<class ItemType>
void insert(TreeType<ItemType> &tree)
{
	string value;

	cout << "\nEnter String: ";
	cin >> value;

	tree.InsertItem(value);

	cout << "\nInsert Complete!" << endl;
	system("PAUSE");
	system("CLS");
}

template<class ItemType>
void Print(TreeType<ItemType> &tree)
{
	tree.PrintTree();
}

template<class ItemType>
void Search(TreeType<ItemType> &tree)
{
	string item;
	cout << "\nEnter value: ";

	cin >> item;
	tree.SearchTree(item);

	system("PAUSE");
	system("CLS");
}

int main()
{
	typedef TreeType<string> tree_type;
	tree_type tree;

	bool exit = false;

	while (!exit)
	{
		cout << "1. Insert" << endl;
		cout << "2. Print" << endl;
		cout << "3. Search" << endl;
		cout << "4. Exit Application" << endl;
		cout << "Enter Option: ";

		int option;
		cin >> option;

		switch (option)
		{
			case 1:
				insert(tree);
				break;
			case 2:
				Print(tree);
				break;
			case 3:
				Search(tree);
				break;
			case 4:
				cout << "\nGoodbye :)" << endl;
				exit = true;
				break;
			default:
				cout << "Incorrect Option" << endl;
				break;
		}
	}
}



