#include <iostream>

using namespace std;

int main()
{
    for(int x = 24; x > 0; x -=3)
    {
        cout << x << endl;

        if(x % 5 == 0)
        {
            break;
        }
    }
}
