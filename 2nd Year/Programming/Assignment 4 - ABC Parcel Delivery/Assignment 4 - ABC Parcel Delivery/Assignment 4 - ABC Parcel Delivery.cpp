// Assignment 4 - ABC Parcel Delivery.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "TwoDayPackage.h"
#include "OvernightPackage.h"
#include "Person.h"

void option1(vector <CPackage*> packageVect);
void option2(vector <CPackage*> packageVect);
void option3(vector <CPackage*> packageVect);
void option4(vector <CPackage*> packageVect);
void menu(vector <CPackage*> packageVect);
void returnToMenu(vector <CPackage*> packageVect);

int main()
{
	vector <CPackage*> packageVect;
	menu(packageVect);
}

void menu(vector <CPackage*> packageVect)
{
	int option;

	cout << "----------------------------" << endl;
	cout << "     ABC Parcel Delivery  " << endl;
	cout << "----------------------------" << endl;
	cout << "1. Create Parcel" << endl;
	cout << "2. Display Shipping details" << endl;
	cout << "3. Cost Analysis" << endl;
	cout << "4. Display Couriers details" << endl;
	cout << "----------------------------" << endl;

	cout << "\nEnter option: ";
	cin >> option;

	switch (option)
	{
	case 1:
		system("CLS");
		option1(packageVect);
		break;
	case 2:
		system("CLS");
		option2(packageVect);
		break;
	case 3:
		system("CLS");
		option3(packageVect);
		break;
	case 4:
		cout << "GoodBye" << endl;
		break;
	default:
		system("cls");
		cout << "\nIncorrect Option!\n" << endl;
	}
}

void option1(vector <CPackage*> packageVect)
{
	cout << "----------------------------" << endl;
	cout << "     Create Package         " << endl;
	cout << "----------------------------" << endl;
	
	int type; 

	cout << "1.Create Overnight Package" << endl;
	cout << "2.Create Two Day Package" << endl;
	cout << "----------------------------" << endl;
	cout << "Enter Type of Package: ";
	cin >> type;
	
	/*
	if (type = 1)
	{
		//CPackage *ptr = new CTwoDayPackage;
		CPackage package;
		package.getUserInput();
		packageVect.push_back(package);
	}
	
	else if(type = 2)
	{
		CPackage package;
		package.getUserInput();
		packageVect.push_back(new COvernightPackage);
	}	
	*/
}

void option2(vector <CPackage*> packageVect)
{
	cout << "Function Coming Soon!" << endl;
}
void option3(vector <CPackage*> packageVect)
{
	cout << "Function Coming Soon!" << endl;
}
void option4(vector <CPackage*> packageVect)
{
	cout << "Function Coming Soon!" << endl;
}

void returnToMenu(vector <CPackage*> packageVect)
{
	cout << "\n----------------------" << endl;
	cout << "\n    Complete! " << endl;
	cout << "\n----------------------" << endl;
	system("PAUSE");
	system("CLS");

	menu(packageVect);
}