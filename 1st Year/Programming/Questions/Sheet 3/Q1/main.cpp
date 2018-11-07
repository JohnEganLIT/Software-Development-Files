#include <iostream>

using namespace std;

int main()
{
    int mark, numFirstClass = 0;
    const int gradeMark = 70;
    double percentFirstClass;

    for(int x = 0; x < 10; x++)
    {
        cout << "Enter Mark: ";
        cin >> mark;

        if(mark >= gradeMark)
            numFirstClass ++;

    }

    percentFirstClass = (double)numFirstClass /10 * 100;
    cout << percentFirstClass  << "% gained first class marks." << endl;

}
