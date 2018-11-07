#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    double price, discount = 0.00, discountRate = 10.00;

    cout << "Enter Price of Item: $";
    cin >> price;

    if(price >= 100)
    {
        discount = price * discountRate / 100;
    }

    cout << "The discount on this item is: $" << fixed << setprecision(2) << discount;

}
