#include <iostream>

using namespace std;

int main()
{
    int departure, arrival, departMins, arrivalMins, totalMins, hours, mins;

    cout << "Enter Departure Time(24hr): " ;
    cin >> departure;

    cout << "Enter Arrival Time(24hr): " ;
    cin >> arrival;

    departMins = departure / 100 * 60 + departure % 100;
    arrivalMins = arrival / 100 * 60 + arrival % 100;

    totalMins = arrivalMins - departMins;

    hours = totalMins / 60;
	mins = totalMins % 60;

	cout << "The journey time is " << hours << " hours and " << mins << " minutes." << endl;

}
