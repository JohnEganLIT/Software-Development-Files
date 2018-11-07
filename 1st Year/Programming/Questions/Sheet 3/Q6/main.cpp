#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    int hour, minute;
    for(hour = 0; hour < 24; hour++)
    {
        for(int minute = 0; minute < 60; minute++)
        {
            cout << setw(2) << setfill('0') << hour << ":" << setw(2) << setfill('0') << minute << endl;
            cin.get();
        }
        cin.get();
    }

}
