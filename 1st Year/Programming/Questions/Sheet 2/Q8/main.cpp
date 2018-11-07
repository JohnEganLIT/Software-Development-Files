#include <iostream>

using namespace std;

int main()
{
    double loan, interest;

    cout << "Enter Size of Loan: $";
    cin >> loan;

    if( loan < 1000)
    {
        interest = 5;
    }

    else if(loan < 5000)
    {
        interest = 5.5;
    }

    else if(loan < 10000)
    {
        interest = 6.5;
    }

    else
    {
        interest = 8;
    }

    cout << "Interest on this loan is " << interest << "%" << endl;

}
