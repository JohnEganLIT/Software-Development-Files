#include "stdafx.h"
#include "Package.h"

CPackage::CPackage()
:m_weight(0), m_costPerOunce(0)
{
}

CPackage::~CPackage()
{
}

void CPackage::getUserInput()
{
	cout << "Enter Package Weight:";
	cin >> m_weight;

	cout << "Enter Cost Per Ounce:";
	cin >> m_costPerOunce;
}

void CPackage::display()
{
	cout << "Name: " << m_weight << endl;
	cout << "Cost Per Ounce:" << m_costPerOunce << endl;
}