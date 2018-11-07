#pragma once
#include "pch.h"
#include "CGate.h"
class COrGate : public CGate
{
public:
	COrGate();
	~COrGate();

	void calculate() override
	{
		cout << "COrGate" << endl;
		cout << "Num 1 + Num 2 =" << num1 + num2 << endl;
	}
};

