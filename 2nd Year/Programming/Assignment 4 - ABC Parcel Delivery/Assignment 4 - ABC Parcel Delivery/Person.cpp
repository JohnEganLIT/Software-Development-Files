#include "stdafx.h"
#include "Person.h"


CPerson::CPerson()
	:m_name(""), m_address(""), m_city(""), m_state(""), m_zip("")
{
}

CPerson::~CPerson()
{
}

void CPerson::getUserInput()
{
	cout << "Enter Name:";
	cin >> m_name;

	cout << "Enter Address:";
	cin >> m_address;

	cout << "Enter City:";
	cin >> m_city;

	cout << "Enter State:";
	cin >> m_state;

	cout << "Enter Zip:";
	cin >> m_zip;
}

void CPerson::display()
{
	cout << "Name: " << m_name << endl;
	cout << "Address: " << m_address << endl;
	cout << "City: " << m_city << endl;
	cout << "State: " << m_state << endl;
	cout << "Zip: " << m_zip << endl;
}