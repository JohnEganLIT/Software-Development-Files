#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    double length, width, area;

    cout << "Enter Length of football pitch(two decimal places): ";
    cin >> length;

    cout << "Enter width of football pitch(two decimal places): ";
    cin >> width;

    area = length * width;

    cout << "The football pitch is " << setprecision(2) << fixed << area << "sq.m." << endl;

}
