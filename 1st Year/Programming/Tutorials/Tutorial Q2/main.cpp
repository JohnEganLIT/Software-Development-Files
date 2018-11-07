#include <iostream>

using namespace std;

int main()
{
    int month, days;
    double dailyRate, percentDiscount, totalDiscount, totalCost;

    cout << "Enter Hire Month Number: ";
    cin >> month;

    if(month > 2 && month < 11)
    {
        cout << "Enter Number of Days: ";
        cin >> days;


        switch(month)
        {
            case 3:
            case 4:
                dailyRate = 100;
                break;

            case 5:
            case 6:
            case 9:
            case 10:
                dailyRate = 250;
                break;

            case 7:
            case 8:
                dailyRate = 400;
                break;

            default:
                cout << "Invalid Input" << endl;
        }

        if(days <= 15)
        {
            percentDiscount = 0;
        }
        else if(days <= 30)
        {
            percentDiscount = 5;
        }

        else if(days <= 60)
        {
            percentDiscount = 10;
        }

        else
        {
            percentDiscount = 15;
        }

        totalDiscount = (dailyRate * days) * (percentDiscount / 100);
        totalCost = (dailyRate * days) - totalDiscount;

        cout << "Your total cost is $" << totalCost << endl;
        }

    else
    {
        cout << "Sorry, yachts are not available for hire during these months" << endl;
    }
}
