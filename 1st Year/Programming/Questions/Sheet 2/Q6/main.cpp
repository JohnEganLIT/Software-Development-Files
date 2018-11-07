#include <iostream>

using namespace std;

int main()
{
    int age, points;

    cout << "Enter Age:";
    cin >> age;

    cout << "Enter Penalty Points:";
    cin >> points;

    if(age >= 21 || points <= 4)
    {
        cout << "Congratulations, you are eligible for Insurance." << endl;
    }

    else
    {
        cout << "Sorry, you are not eligible for Insurance." << endl;
    }

}
