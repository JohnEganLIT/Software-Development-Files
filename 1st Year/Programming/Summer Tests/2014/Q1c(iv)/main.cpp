#include <iostream>

using namespace std;

int main()
{
    for(int x = 1; x < 30; x += 3)
    {
        cout << x << " ";

        if(x % 13 == 0)
        {
            break;
        }
    }
}
