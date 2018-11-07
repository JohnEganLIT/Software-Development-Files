#include <iostream>

using namespace std;

int main()
{
    for(int x = 1; x <= 100; x++)
    {

        if(0 == x % 3 && 0 == x % 8)
        {
            cout << x << endl;
        }

    }

}
