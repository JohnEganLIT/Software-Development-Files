#pragma once
#include "Person.h"
class CWaged : public CPerson
{
public:
	void CWaged::getUserInput();
	void CWaged::displayWaged();

private:
	float m_hourlyRate;
	int m_hoursWorked;
};

