#include <iostream>
#include <iomanip>

using namespace std;

int main()
{
    const double stCharge = 0.20, surcharge = 10;
    int startKm, endKm, distance;
    double totalCharge;

    cout << "Enter Initial and final KM Readings: " << endl;
    cin >> startKm >> endKm;

    distance = endKm - startKm;

    totalCharge = distance * stCharge + distance/1000 * surcharge;

    cout << "You travelled " << distance << "km." << endl;
    cout << "This adds up to $" << fixed << setprecision(2) << totalCharge << "." << endl;

}
