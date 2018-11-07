#include <iostream>

using namespace std;

int GetResult(int x, int y);

int main()
{
   GetResult(10, 34);
}

int GetResult(int x, int y)
{
    int result = 0;

    for(int i = 1; i <= x; i++)
    {
        result += i * y;
    }

    return result;
}

