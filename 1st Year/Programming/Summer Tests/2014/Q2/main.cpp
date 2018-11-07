#include <iostream>
#include <fstream>

using namespace std;

int main()
{
    string kNumber[20];
    int mark[20], grade[20];

    ifstream infile("marks.dat");
    ofstream outfile("grades.dat");

    for(int x = 0; x < 20; x++)
    {
        infile >> kNumber[x] >> mark[x];

        if(mark[x] < 40)
            grade[x] = 'F';

        else if(mark[x] < 50)
            grade[x] = 'E';

        else if(mark[x] < 60)
            grade[x] = 'D';

        else if(mark[x] < 70)
            grade[x] = 'C';

        else if(mark[x] < 85)
            grade[x] = 'B';

        else
            grade[x] = 'A';

        outfile << kNumber[x] << " " << grade[x];

    }
    infile.close();
    outfile.close();

}
