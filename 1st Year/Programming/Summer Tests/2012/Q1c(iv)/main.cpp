#include <iostream>

using namespace std;

int main()
{
    for(int x = 1; x < 15; x += 3)
    {
        cout << x << endl;

        if(x % 5 == 0)
            break;
    }
}
