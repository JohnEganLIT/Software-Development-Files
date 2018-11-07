#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    char payType;
    double salary, hourlyRate, allowance, grossPay, tax, netPay, taxRate;
    int hours;

    cout << "Enter S for Salaried or W for Waged: ";
    cin >> payType;

    if(payType == 'S' || payType == 's' || payType == 'W' || payType == 'w')
    {
        if(payType == 'S' || payType == 's')
        {
            cout << "Enter Annual Salary: $";
            cin >> salary;

            cout << "Enter Tax Rate: $";
            cin >> taxRate;

            cout << "Enter Annual Tax Free Allowance: $";
            cin >> allowance;

            grossPay = salary / 12;
            tax = (grossPay - allowance / 12) * (taxRate/100);
            netPay = grossPay - tax;

            cout << "Your Total Monthly Pay is $" << fixed << setprecision(2) << netPay << endl;
        }

        if(payType == 'W' || payType == 'w')
        {
            cout << "Enter Hourly Rate: $";
            cin >> hourlyRate;

            cout << "Hours worked: ";
            cin >> hours;

            cout << "Enter Tax Rate: $";
            cin >> taxRate;

            cout << "Enter Annual Tax Free Allowance: $";
            cin >> allowance;

            grossPay = hours * hourlyRate;

            if(grossPay < allowance)
            {
                netPay = grossPay;
                cout << "Your Total Weekly Pay is $" << fixed << setprecision(2) << netPay << endl;
            }

            else
            {
                if(hours > 40)
                {
                    grossPay += (hours - 40)*(hourlyRate * 0.5);
                    tax = (grossPay - allowance/52)* taxRate/100;
                    netPay = grossPay - tax;

                    cout << "Your Total Weekly Pay is $" << fixed << setprecision(2) << netPay << endl;
                }

                else
                {
                    tax = (grossPay - allowance/52)* taxRate/100;
                    netPay = grossPay - tax;
                    cout << "Your Total Weekly Pay is $" << fixed << setprecision(2) << netPay << endl;
                }
            }

        }
    }

    else
    {
        cout << "Invalid Entry" << endl;
    }

}

