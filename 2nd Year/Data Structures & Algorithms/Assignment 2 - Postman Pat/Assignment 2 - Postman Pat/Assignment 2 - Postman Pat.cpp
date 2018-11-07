#include "stdafx.h"

using namespace std; 

int main()
{
	vector <bool> postbox(150);
	int start = 1;

	for (int increment = 2; increment < 150; increment++)
	{
		for (int i = start; i < 150; i += increment) 
		{
			if (postbox[i] == 0)
			{
				postbox[i] = 1;
			}

			else if (postbox[i] == 1)
			{
				postbox[i] = 0;
			}
		}
		start++;
	}	

	for (int i = 0; i < 150; i++)
	{
		cout << postbox[i] << " ";
	}
	cout << endl;
}

