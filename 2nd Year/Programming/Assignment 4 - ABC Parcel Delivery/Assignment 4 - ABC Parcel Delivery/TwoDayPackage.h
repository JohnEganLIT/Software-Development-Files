#pragma once
#include "Package.h"
class CTwoDayPackage :
	public CPackage
{
public:
	CTwoDayPackage();
	~CTwoDayPackage();

	void getUserInput();
	void display();
private:
	float m_flatFee;
};

