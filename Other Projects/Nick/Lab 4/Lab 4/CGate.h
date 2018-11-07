#pragma once
class CGate
{
public:
	CGate();
	~CGate();

	virtual void setNum1(int);
	virtual void setNum2(int);

	virtual void calculate();

protected:
	int num1;
	int num2;
};

