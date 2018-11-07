#include "pch.h"
#include "CAndGate.h"
#include "COrGate.h"

int main()
{
	CAndGate andGate;
	COrGate orGate;

	// Pointer to CGate.
	CGate* anyGate;

	// Sets anyGate to point to instace of CAndGate.
	anyGate = &andGate;

	// Calls functions in andGate. 
	anyGate->setNum1(5);
	anyGate->setNum2(10);
	anyGate->calculate();

	// Sets anyGate to point to instance of COrGate. 
	anyGate = &orGate;

	// Calls functions in orGate. 
	anyGate->setNum1(2);
	anyGate->setNum2(4);
	anyGate->calculate();

}

