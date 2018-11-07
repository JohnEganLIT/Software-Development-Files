#include <iostream>

using namespace std;

int main()
{
    cout << "Displaying even numbers\n";

    for(int x = 0; x < 10; x++)
    {
        if(x % 2 == 0)
            cout << x << endl;
    }

    cout << "Displaying odd numbers\n";

    int y = 0;

    do
    {
        if(y % 2 != 0)
            cout << y << endl;
        y++;
    }while(y < 10);
}
