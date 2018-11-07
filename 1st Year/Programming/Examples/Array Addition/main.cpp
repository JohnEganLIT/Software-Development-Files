#include <iostream>

using namespace std;

int main()
{
    int colin[] = {7, 4, 5, 8, 2};
    int sum = 0;

    for(int x = 0; x < 5; x++)
    {
        sum += colin[x];
        cout << sum << endl;
    }
}
