#include "stdafx.h"

using namespace std;

struct weatherStruct
{
	int day;
	int month;
	int year;
	string name;
	float rainfall;
	float sunshine;
	float temperature;
};

void staff(vector <weatherStruct> weather);
void wetDays(vector <weatherStruct> weather);
void sunnyDays(vector <weatherStruct> weather);
void averageRain(vector <weatherStruct> weather);
void hottestDay(vector <weatherStruct> weather);
void shortestSunshineDay(vector <weatherStruct> weather);
void exitApplication();
void clearScreen();
void menu();

int main()
{
	clearScreen();

	int option;
	vector <weatherStruct> weather(30);

	cout << "1) List the dates when a given meteorologist was on duty." << endl;
	cout << "2) Find all the wet days(i.e.rainfall >= 4mm)." << endl;
	cout << "3) Find all the sunny days(i.e.sun hours >= 5 hours)." << endl;
	cout << "4) Find the average rainfall between two dates." << endl;
	cout << "5) Find the hottest day based on the midday temperature." << endl;
	cout << "6) Find the day with the shortest sunshine." << endl;
	cout << "7) Exit from the application.\n" << endl;

	ifstream infile("weather.txt");

	for (int i = 0; i < weather.size(); i++)
	{
		infile >> weather[i].day >> weather[i].month >> weather[i].year >> weather[i].name >> weather[i].rainfall >> weather[i].sunshine >> weather[i].temperature;
	}

	infile.close();

	cout << "Enter Option: ";
	cin >> option;

	switch (option)
	{
	case 1:
		clearScreen();
		staff(weather);
		break;
	case 2:
		clearScreen();
		wetDays(weather);
		break;
	case 3:
		clearScreen();
		sunnyDays(weather);
		break;
	case 4:
		clearScreen();
		averageRain(weather);
		break;
	case 5:
		clearScreen();
		hottestDay(weather);
		break;
	case 6:
		clearScreen();
		shortestSunshineDay(weather);
		break;
	case 7:
		clearScreen();
		exitApplication();
		break;
	default:
		clearScreen();
		cout << "Invalid Option!" << endl;
		main();
	}
}

void staff(vector <weatherStruct> weather)
{
	cout << "\nStaff" << endl;
	cout << "-----" << endl;

	vector <string> names(30);

	cout << "Tommy" << endl;
	cout << "Tim" << endl;
	cout << "Tommy" << endl;
	cout << "John" << endl;
	cout << "Mickey\n" << endl;

	/*
	for (int x = 0; x < names.size(); x++)
	{
	for (int i = 0; i < weather.size(); i++)
	{
	if (names[x] == weather[i].name)
	{
	//cout << "Found Something " << weather[i].name << names[x] << endl;
	}

	else if(names[x] != weather[i].name)
	{
	names[x] = weather[i].name;
	}
	cout << names[i] << endl;
	}
	}

	*/
	string name;
	cout << "Enter Name: ";
	cin >> name;

	cout << name << " was on duty on these dates." << endl;

	for (int i = 0; i < weather.size(); i++)
	{
		if (weather[i].name == name)
		{
			cout << weather[i].day << "/" << weather[i].month << "/" << weather[i].year << endl;
		}
	}

	cout << endl;

	menu();
}

void wetDays(vector <weatherStruct> weather)
{
	cout << "Days with over 4mm of rainfall" << endl;
	cout << "--------------------------------" << endl;

	for (int i = 0; i < 30; i++)
	{
		if (weather[i].rainfall > 4)
		{
			cout << weather[i].day << "/" << weather[i].month << "/" << weather[i].year << " had " << weather[i].rainfall << "mm of rainfall." << endl;
		}
	}

	cout << endl;

	menu();
}

void sunnyDays(vector <weatherStruct> weather)
{
	cout << "Days with over 5 hours of sunshine" << endl;
	cout << "--------------------------------" << endl;
	for (int i = 0; i < 30; i++)
	{
		if (weather[i].sunshine > 5)
		{
			cout << weather[i].day << "/" << weather[i].month << "/" << weather[i].year << " = " << weather[i].sunshine << " hours of sunshine." << endl;
		}
	}

	cout << endl;

	menu();
}

void averageRain(vector <weatherStruct> weather)
{
	cout << "Average Rainfall" << endl;
	cout << "----------------" << endl;

	int day1, day2, noOfDays = 0;
	float total = 0, average;

	cout << "Enter start day(1-30): ";
	cin >> day1;

	cout << "The average rainfall between ";
	cin >> day2;

	for (int i = 0; i < weather.size(); i++)
	{
		if (weather[i].day == day1)
		{
			cout << weather[i].day << "/" << weather[i].month << "/" << weather[i].year;
		}
	}

	cout << " and ";

	for (int i = 0; i < weather.size(); i++)
	{
		if (weather[i].day == day2)
		{
			cout << weather[i].day << "/" << weather[i].month << "/" << weather[i].year;
		}
	}

	for (int i = 0; i < weather.size(); i++)
	{
		if (weather[i].day >= day1 && weather[i].day <= day2)
		{
			total += weather[i].rainfall;
			noOfDays++;
		}
	}

	average = total / noOfDays;
	cout << " is " << setprecision(2) << average << "mm" << endl;

	cout << endl;

	menu();
}

void hottestDay(vector <weatherStruct> weather)
{
	cout << "Highest Temperature" << endl;
	cout << "-------------------" << endl;

	float temp = weather[0].temperature;

	for (int i = 1; i < weather.size(); i++)
	{
		if (weather[i].temperature > temp)
		{
			temp = weather[i].temperature;
		}
	}

	for (int i = 1; i < weather.size(); i++)
	{
		if (weather[i].temperature == temp)
		{
			cout << weather[i].day << "/" << weather[i].month << "/" << weather[i].year << " was the hottest day, reaching a temperature of " << weather[i].temperature << " degrees celcius." << endl;
		}
	}

	cout << endl;

	menu();
}

void shortestSunshineDay(vector <weatherStruct> weather)
{
	cout << "Day with least sunshine" << endl;
	cout << "-----------------------" << endl;

	float sun = weather[0].sunshine;

	for (int i = 1; i < weather.size(); i++)
	{
		if (weather[i].sunshine < sun)
		{
			sun = weather[i].sunshine;
		}
	}

	for (int i = 1; i < weather.size(); i++)
	{
		if (weather[i].sunshine == sun)
		{
			cout << weather[i].day << "/" << weather[i].month << "/" << weather[i].year << " was the day with the least sunshine, with " << weather[i].sunshine << " hours of sunshine." << endl;
		}
	}

	cout << endl;

	menu();
}

void exitApplication()
{
	cout << "Goodbye" << endl;
}

void menu()
{
	system("pause");
	main();
}

void clearScreen()
{
	system("cls");
}






