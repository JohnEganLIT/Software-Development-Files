#include <iostream>

using namespace std;

int main()
{
    int totalDays, weeks, days;

    cout << "Enter total number of days: ";
    cin >> totalDays;

    weeks = totalDays / 7;
    days = totalDays % 7;

    cout << weeks << " weeks and " << days << " days." << endl;

}
