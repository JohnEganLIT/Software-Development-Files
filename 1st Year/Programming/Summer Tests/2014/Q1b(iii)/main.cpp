#include <iostream>

using namespace std;

void multTable(int value)
{
    int index = 1, result;

    while (index <= value)
    {
        result = index * value;
        cout << index << "x" << value << " = " << result << endl;
    }

}

int main()
{
    multTable(99);
}

