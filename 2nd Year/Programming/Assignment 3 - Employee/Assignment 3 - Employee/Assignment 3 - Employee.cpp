#include "stdafx.h"
#include "waged.h"
#include "salaried.h"

void menu(vector <CWaged> waged, vector <CSalaried> salaried);
void option1(vector <CWaged> waged, vector <CSalaried> salaried);
void option2(vector <CWaged> waged, vector <CSalaried> salaried);
void option3(vector <CWaged> waged, vector <CSalaried> salaried);
void returnToMenu(vector <CWaged> waged, vector <CSalaried> salaried);

int main()
{
	vector <CWaged> waged;
	vector <CSalaried> salaried;
	
	menu(waged, salaried);
}

void menu(vector <CWaged> waged, vector <CSalaried> salaried)
{
	int option;

	cout << "-----------------------" << endl;
	cout << "        Employee       " << endl;
	cout << "-----------------------" << endl;
	cout << "1. Add Waged Employee" << endl;
	cout << "2. Add Salaried Employee" << endl;
	cout << "3. Display Employees" << endl;
	cout << "-----------------------" << endl;

	cout << "\nEnter option: ";
	cin >> option;

	switch (option)
	{
	case 1:
		system("CLS");
		option1(waged, salaried);
		break;
	case 2:
		system("CLS");
		option2(waged, salaried);
		break;
	case 3:
		system("CLS");
		option3(waged, salaried);
		break;
	case 6:
		cout << "GoodBye" << endl;
		break;
	default:
		system("cls");
		cout << "\nIncorrect Option!\n" << endl;
		menu(waged, salaried);
	}
}

void option1(vector <CWaged> waged, vector <CSalaried> salaried)
{
	cout << "------------------------" << endl;
	cout << "    Add Waged Employee  " << endl;
	cout << "------------------------" << endl;

	CWaged temp;
	temp.getUserInput();
	waged.push_back(temp);

	returnToMenu(waged, salaried);
}

void option2(vector <CWaged> waged, vector <CSalaried> salaried)
{
	cout << "------------------------" << endl;
	cout << " Add Salaried Employee  " << endl;
	cout << "------------------------" << endl;

	CSalaried temp;
	temp.getUserInput();
	salaried.push_back(temp);

	returnToMenu(waged, salaried);
}

void option3(vector <CWaged> waged, vector <CSalaried> salaried)
{
	cout << "----------------------" << endl;
	cout << "   Display Employees  " << endl;
	cout << "----------------------" << endl;

	cout << "Waged Employees" << endl;
	cout << "------------------" << endl;

	for (int i = 0; i < waged.size(); i++)
	{
		CWaged temp = waged[i];
		temp.displayWaged();
	}

	cout << "\n------------------" << endl;
	cout << "Salaried Employees" << endl;
	cout << "------------------" << endl;

	for (int i = 0; i < salaried.size(); i++)
	{
		CSalaried temp = salaried[i];
		temp.displaySalaried();
	}

	returnToMenu(waged, salaried);
}

void returnToMenu(vector <CWaged> waged, vector <CSalaried> salaried)
{
	cout << "\n----------------------" << endl;
	cout << "\n    Complete!" << endl;
	cout << "\n----------------------" << endl;
	system("PAUSE");
	system("CLS");

	menu(waged, salaried);
}