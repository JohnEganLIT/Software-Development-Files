#pragma once
class CPackage
{
public:
	CPackage();
	~CPackage();

	void getUserInput();
	void display();
protected:
	float m_weight;
	float m_costPerOunce;
};

