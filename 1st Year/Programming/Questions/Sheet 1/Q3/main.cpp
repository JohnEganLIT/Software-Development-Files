#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
	int firstNumber, secondNumber, answer;

	cout << "Please enter the first number: ";
	cin >> firstNumber;
	cout << "Please enter the second number: ";
	cin >> secondNumber;

	answer = firstNumber + secondNumber;
	cout << firstNumber << " + " << secondNumber << " = " << answer << endl;

	answer = firstNumber - secondNumber;
	cout << firstNumber << " - " << secondNumber << " = " << answer << endl;

	answer = firstNumber * secondNumber;
	cout << firstNumber << " * " << secondNumber << " = " << answer << endl;

	answer = firstNumber / secondNumber;
	cout << firstNumber <<  " / " << secondNumber << " = " << answer << endl;

	answer = firstNumber % secondNumber;
	cout <<  firstNumber <<  " % " << secondNumber << " = " << answer << endl;

}


