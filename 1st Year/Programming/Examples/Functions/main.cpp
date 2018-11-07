#include <iostream>

using namespace std;

void calculator()
{
    int x, y, answer;

    cout << "Enter 2 numbers to add: " << endl;
    cin >> x;
    cin >> y;

    answer = x + y;
    cout << x << " + " << y << " = " << answer << endl;
}

void calculator2(int x, int y)
{
    int answer;

    answer = x + y;
    cout << x << " + " << y << " = " << answer << endl;
}

int main()
{
    calculator();
    calculator2(20, 10);
}
