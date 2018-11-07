#include <iostream>

using namespace std;

int main()
{
    int colin[2][3] = {{1, 6, 4},{5, 7, 3}};

    //1,6,4
    //5,7,3

    for(int row = 0; row < 2; row++)
    {
        for(int col = 0; col < 3; col++)
            {
               cout << colin[row][col] << " ";
            }
        cout << endl;
    }

}
