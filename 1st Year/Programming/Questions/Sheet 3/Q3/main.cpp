#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    int mark, numStudents = 0, numFirstClass=0;
	const int gradeMark = 70;
	double percentFirstClass;
	cout << "Enter a mark : ";
	cin >> mark;
	while ( mark != -1)
	{

		if ( mark != -1 )
		{
			numStudents++;
			if ( mark >= 70 )
				numFirstClass++;
		}
		cout << "Enter a mark : ";
		cin >> mark;

	}

		percentFirstClass = (double) numFirstClass / numStudents * 100;
		cout << percentFirstClass << "% gained first class marks\n" ;

	return 0;
}
