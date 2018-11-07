#pragma once
#include "Person.h"
class CSalaried : public CPerson
{
public:	
	void getUserInput();
	void displaySalaried();
private:
	float m_annualSalary;
};

