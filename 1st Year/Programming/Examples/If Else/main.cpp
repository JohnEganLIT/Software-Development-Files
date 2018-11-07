#include <iostream>

using namespace std;

int main()
{
    int age, year = 2014, birth, birth2;

    cout << "Enter Age:";
    cin >> age;

    birth = year - age;
    birth2 = birth - 1;

    if(birth >= 1870 && birth < 2015)
    {
        if(birth >= 1950 && birth < 1970)
        {
            cout << "You are getting old ;)." << endl;
        }

        if(birth >= 1970 && birth < 1985)
        {
            cout << "You have a couple of years left yet ;)." << endl;
        }

        if(birth >= 1985 && birth < 2005)
        {
            cout << "Young person, why are you not out there doing stuff O_o." << endl;
        }

        if(birth >= 2005 && birth < 2015)
        {
            cout << "Lickle baby is all you are." << endl;
        }

        cout << "At " << age << " years old, you were either born in " << birth2 << " or " << birth << "." << endl;
    }

    else
    {
        cout << "Stop fucking with the program!" << endl;
    }
}
