#include <iostream>

using namespace std;

void printNumber(int x)
{
    cout << x << endl;
}

void printNumber(double x)
{
    cout << x << endl;
}

int main()
{
    int a = 54;
    double b = 32.1234;

    printNumber(a);
    printNumber(b);
}
