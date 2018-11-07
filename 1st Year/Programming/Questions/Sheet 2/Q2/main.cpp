#include <iostream>

using namespace std;

int main()
{
    double stdCharge = 20, unitCharge = 0.05, previous, present, bill;

    cout << "Enter Previous Reading: ";
    cin >> previous;

    cout << "Enter Present Reading: ";
    cin >> present;

    if(present > previous)
		{
			bill = stdCharge + (present - previous) * unitCharge;
		}

	if(present < previous)
		{
			bill = stdCharge + (present + 10000 - previous) * unitCharge;
		}

    cout << "Your Bill is: $" << bill << endl;

}
