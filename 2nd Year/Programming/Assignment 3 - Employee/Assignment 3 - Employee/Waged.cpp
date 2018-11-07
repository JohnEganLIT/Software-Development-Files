#include "stdafx.h"
#include "Waged.h"

void CWaged::getUserInput()
{
	cout << "Enter Name: ";
	cin >> m_name;

	cout << "Enter Employee Number: ";
	cin >> m_employeeNum;

	cout << "Enter Hourly Rate: ";
	cin >> m_hourlyRate;

	cout << "Enter Hours Worked: ";
	cin >> m_hoursWorked;
}

void CWaged::displayWaged()
{
	cout << "Name: " <<  m_name << endl;
	cout << "Employee Number: " << m_employeeNum << endl;
	cout << "Weekly wages: " << fixed << setprecision(2) << m_hourlyRate * m_hoursWorked << endl;
}
