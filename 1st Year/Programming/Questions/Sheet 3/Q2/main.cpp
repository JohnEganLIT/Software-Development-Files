#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    int mark, numFirstClass = 0, classSize;
    const int gradeMark = 70;
    double percentFirstClass;

    cout << "Enter Size of Class: ";
    cin >> classSize;

    for(int x = 0; x < classSize; x++)
    {
        cout << "Enter Mark: ";
        cin >> mark;

        if(mark >= gradeMark)
            numFirstClass ++;

    }

    percentFirstClass = (double)numFirstClass / classSize * 100;
    cout << fixed << setprecision(2) << percentFirstClass  << "% gained first class marks." << endl;

}
