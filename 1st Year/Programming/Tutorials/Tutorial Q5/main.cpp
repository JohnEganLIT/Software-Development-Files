#include <iostream>
#include <fstream>

using namespace std;

int main()
{
    int picture1[50][20], picture2[50][20], difference, percentDifference;

    ifstream infile("picture1.dat");

    for(int row = 0; row < 50; row++)
    {
        for(int col = 0; col < 20; col++)
        {
            infile >> picture1[row][col];
        }
    }
    infile.close();

    ifstream infile2 ("picture2.dat");

    for(int row = 0; row < 50; row++)
    {
        for(int col = 0; col < 20; col++)
        {
            infile2 >> picture2[row][col];
        }
    }
    infile2.close();

    for(int row = 0; row < 50; row++)
    {
        for(int col = 0; row < 20; row++)
        {
            if(picture1[row][col] != picture2[row][col])
                difference++;
        }
    }

    percentDifference = double(difference) / 1000 *100;

    if(percentDifference <= 5)
    {
        cout << "Images are identical" << endl;
    }

    else
    {
        cout << "Images are not identical" << endl;
    }
}

