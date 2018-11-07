#include "stdafx.h"
#include "TwoDayPackage.h"


CTwoDayPackage::CTwoDayPackage()
{
	m_flatFee = 0;
}

CTwoDayPackage::~CTwoDayPackage()
{
}

void CTwoDayPackage::getUserInput()
{
	cout << "Enter Flat Fee:";
	cin >> m_flatFee;
}

void CTwoDayPackage::display()
{
	cout << "Flat Fee:" << m_flatFee << endl;
}
