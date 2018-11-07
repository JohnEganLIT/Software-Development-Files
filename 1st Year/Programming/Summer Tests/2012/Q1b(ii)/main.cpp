#include <iostream>

using namespace std;

int main()
{
    int x;

    cin >> x;

    switch(x)
    {
    case 1:
        cout << "Option 1\n";
        break;

    case 2:
        cout << "Option 2\n";
        break;

    default:
        cout << "Invalid Option\n";
    }
}
