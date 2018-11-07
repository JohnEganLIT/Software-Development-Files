#include <iostream>

using namespace std;

int main()
{
    int age, points;
    double carValue, valueFactor = 10.0, ageFactor, pointsFactor, cost;

    cout << "Enter Value of Car, Age and Number of Penalty Points: " << endl;
    cin >> carValue >> age >> points;

    if(age >= 18 && points < 9)
    {
        if(age < 21)
            ageFactor = 2.0;

        else if(age <= 25)
            ageFactor = 1.5;

        else
            ageFactor = 1.0;


        switch(points)
        {
            case 5:
                pointsFactor = 1.1;
                break;

            case 6:
                pointsFactor = 1.2;
                break;

            case 7:
                pointsFactor = 1.4;
                break;

            default:
                pointsFactor = 1.0;

        }
    }

    else if(age < 18)
    {
        cout << "Sorry you are too young to be insured with us" << endl;
    }

    else
    {
        cout << "Sorry, you have too many penalty points to be insured with us" << endl;
    }

    cost = ( 250 + (carValue/1000) * valueFactor )  * ageFactor  * pointsFactor;

    cout << "Your insurance policy will cost $" << cost << "." << endl;

}
