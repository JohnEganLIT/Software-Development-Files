#pragma once
#include "Package.h"
class COvernightPackage :
	public CPackage
{
public:
	COvernightPackage();
	~COvernightPackage();
private:
	float m_feePerOunce;
};

