#include <iostream>

using namespace std;

int main()
{
    double salary, percent, increase;

    cout << "Enter Salary: ";
    cin >> salary;

    cout << "Enter Yearly Percentage Increase: ";
    cin >> percent;

    for(int x = 1; x < 5; x++)
    {
        salary *= (100 + percent)/100;
        cout << "Year " << x << ": $" << salary << endl;
    }
}
