#include <iostream>
#include <fstream>

using namespace std;

int main()
{
    int grid[10][10];

    ifstream infile("Griddata.dat");

    for(int row = 0; row < 10; row++)
    {
        for(int col = 0; col < 10; col++)
        {
            infile >> grid[row][col];
        }
    }
    infile.close();

    int smallest = grid[0][0];

    for(int row = 0; row < 10; row++)
    {
        for(int col = 0; col < 10; col++)
        {
            if(grid[row][col] < smallest)
                smallest = grid[row][col];
        }
    }

    for(int row = 0; row < 10; row++)
    {
        for(int col = 0; col < 10; col++)
            grid[row][col] -= smallest;
    }
    cout << "The smallest value is "<< smallest << endl;

    for(int row = 0; row < 10; row++)
    {
        for(int col = 0; col < 10; col++)
        {
            cout << grid[row][col] << " ";
        }
        cout << endl;
    }
}
