#include <iostream>

using namespace std;

int main()
{
    int age, points;
    double premium, loading = 25;

    cout << "Enter Age:";
    cin >> age;

    cout << "Enter Penalty Points:";
    cin >> points;

    if(age >= 21 && points <= 4)
    {
        cout << "Congratulations, you are eligible for Insurance." << endl;
        cout << "Enter Basic Insurance Premium: $";
        cin >> premium;

        if(age < 25 || points > 2)
        {
            cout << "You are subject to a 25% loading" << endl;
            premium *= (1 + loading/100);
            cout << "Your premium is $" << premium << endl;
        }

        else
        {
            cout << "You are subject to no extra charges" << endl;
            cout << "Your premium is $" << premium << endl;
        }
    }

    else
    {
        cout << "Sorry, you are not eligible for Insurance." << endl;
    }

}

