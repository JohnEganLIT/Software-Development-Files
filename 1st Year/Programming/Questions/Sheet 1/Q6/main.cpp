#include <iostream>

using namespace std;

int main()
{
    double income, allowance, taxRate, taxDue;

    cout << "Enter Annual Income: $";
    cin >> income;

    cout << "Enter Annual Tax Free Allowance: $";
    cin >> allowance;

    cout << "Enter Annual Tax Rate: %";
    cin >> taxRate;

    taxDue = (income - allowance) * taxRate/100;

    cout << "$" << taxDue << " of tax is due this year." << endl;

}
