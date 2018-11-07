#include <iostream>

using namespace std;

int main()
{
    int month;

    cout << "Enter Month Number: ";
    cin >> month;

    switch(month)
    {
        case 2:
        case 3:
        case 4:
            cout << "Spring" << endl;
            break;

        case 5:
        case 6:
        case 7:
            cout << "Summer" << endl;
            break;

        case 8:
        case 9:
        case 10:
            cout << "Autumn" << endl;
            break;

        case 11:
        case 12:
        case 1:
            cout << "Winter" << endl;
            break;

        default:
            cout << "Invalid Entry" << endl;
    }

}
