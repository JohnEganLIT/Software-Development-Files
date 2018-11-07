#include <iostream>

using namespace std;

int main()
{
    int factorial = 1;

    for(int n = 2; n <= 6; n++)
    {
        factorial *= n;
        cout << factorial << endl;
    }
}


