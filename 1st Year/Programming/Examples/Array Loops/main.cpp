#include <iostream>

using namespace std;

int main()
{
    int numbers[10];

    cout << "Element   -----   Value" << endl;

    for(int x = 0; x < 10; x++)
    {
        numbers[x] = 99;
        cout << x << "                 " << numbers[x] << endl;
    }

    return 0;
}
