#include <iostream>
#include <fstream>

using namespace std;

int main()
{
    float BMI[3], weight[3], height[3];
    string name[3], BMICategory[3];

    for(int x = 0; x < 3; x++)
    {
        cout << "Enter Name: ";
        cin >> name[x];

        cout << "Enter Weigth: ";
        cin >> weight[x];

        cout << "Enter Height: ";
        cin >> height[x];

        BMI[x] = weight[x] / (height[x] * height[x]);

        if(BMI[x] < 18.5)
            BMICategory[x] = "Underweight";

        else if(BMI[x] < 25)
            BMICategory[x] = "Healthy";

        else if(BMI[x] < 30)
            BMICategory[x] = "Overweight";

        else if(BMI[x] < 35)
            BMICategory[x] = "Obese1";

        else if(BMI[x] < 40)
            BMICategory[x] = "Obese2";

        else
            BMICategory[x] = "Obese3";

        cout << name[x] << "You are " << BMICategory[x] << endl;

    }

}
