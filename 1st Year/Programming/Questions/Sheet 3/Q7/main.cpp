#include <iostream>

using namespace std;

int main()
{
	cout << "\n\n\n";
	for ( int row = 0; row < 9; row++ )
	{
		cout << '\t';
		for ( int col = 0; col < 15; col++ )
		{
				if ( row < 3 || row > 5 )
				{
					if ( col < 5 || col > 9 )
						cout << ' ';
					else
						cout << '*';

				}
				else
					cout << '*';
				}
		cout << endl;
	}
	cout << "\n\n\n";

}
