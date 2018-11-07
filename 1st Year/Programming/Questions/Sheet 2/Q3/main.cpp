#include <iostream>

using namespace std;

int main()
{
    int value1, value2;

    cout << "Enter 2 Values: " << endl;
    cin >> value1 >> value2;

    if(value1 < value2)
    {
        cout << "------" << endl;
        cout << "1. " << value2 << endl;
        cout << "2. " << value1 << endl;
    }

    else
    {
        cout << "------" << endl;
        cout << "1. " << value1 << endl;
        cout << "2. " << value2 << endl;
    }

}
