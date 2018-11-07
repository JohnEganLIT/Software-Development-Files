#include <iostream>
#include <fstream>

using namespace std;

int main()
{
    int picture1[50][20], picture2[50][20], differenceCounter = 0, percentDifference;

    ifstream infile("picture1");

    for(int row = 0; row < 50; row++)
    {
        for(int col = 0; row < 20; row++)
            {
                infile >> picture1[row][col];
            }
    }
    infile.close();

    ifstream infile2("picture2");

    for(int row = 0; row < 50; row++)
    {
        for(int col = 0; col < 20; col++)
            {
                infile >> picture2[row][col];
            }
    }
    infile2.close();

    for(int row = 0; row < 50; row++)
    {
        for(int col = 0; col < 50; col++)
        {
            if(picture1[row][col] != picture2[row][col])
                {
                    differenceCounter++;
                }
        }
    }

    percentDifference = double(differenceCounter) / 1000 * 100;

    if(percentDifference > 5)
    {
        cout << "Images are not identical" << endl;
    }

    else
    {
        cout << "Images are identical" << endl;
    }
}
