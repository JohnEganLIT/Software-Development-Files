#include "stdafx.h"
#include "Salaried.h"

void CSalaried::getUserInput()
{
	cout << "Enter Name: ";
	cin >> m_name;

	cout << "Enter Employee Number: ";
	cin >> m_employeeNum;

	cout << "Enter Annual Salary: ";
	cin >> m_annualSalary;
}

void CSalaried::displaySalaried()
{
	cout << "Name: " << m_name << endl;
	cout << "Employee Number: " << m_employeeNum << endl;
	cout << "Weekly salary: " << fixed << setprecision(2) << m_annualSalary / 52 << endl;
}