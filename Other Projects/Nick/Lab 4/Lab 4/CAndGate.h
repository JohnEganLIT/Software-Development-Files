#pragma once
#include "CGate.h"
class CAndGate : public CGate
{
public:
	CAndGate();
	~CAndGate();

	void calculate() override
	{
		cout << "CAndGate" << endl;
		cout << "Num 1 + Num 2 =" << num1 + num2 << endl;
	}
};

