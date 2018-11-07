#include <iostream>

using namespace std;

int main()
{
    int length, width, area;

    cout << "Enter Length of football pitch: ";
    cin >> length;

    cout << "Enter width of football pitch: ";
    cin >> width;

    area = length * width;

    cout << "The football pitch is " << area << "sq.m.";

}
