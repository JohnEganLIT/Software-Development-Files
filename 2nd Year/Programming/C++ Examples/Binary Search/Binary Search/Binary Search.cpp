// Binary Search.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
using namespace std; 

struct ListType
{
	int length;
	int info[8];
};

void binarySearch(ListType list, int item, bool &found)
{
	int first = 0;
	int last = list.length - 1;
	int midPoint;

	bool moreToSearch = first <= last;
	found = false;

	while (moreToSearch && !found)
	{
		midPoint = (first + last) / 2;

		if (item < list.info[midPoint])
		{
			last = midPoint - 1;
			moreToSearch = first <= last;
		}

		else if (item > list.info[midPoint])
		{
			first = midPoint + 1;
			moreToSearch = first <= last;
		}

		else
		{
			found = true;
		}		
	}	
}

void forgetfulBinarySearch(ListType list, int &item, bool &found)
{
	int first = 0;
	int last = list.length - 1;
	int midpoint;

	bool moreToSearch = first <= last;
	found = false;

	while (first < last)
	{
		midpoint = (first + last) / 2;

		if (item > list.info[midpoint])
			first = midpoint + 1;

		else
			last = midpoint;
	}

	if (item == list.info[first])
		found = true;

	else
		found = false;

}

int main()
{
	ListType list;
	list.info[0] = 1;
	list.info[1] = 2;
	list.info[2] = 5;
	list.info[3] = 8;
	list.info[4] = 11;
	list.info[5] = 14;
	list.info[6] = 17;
	list.info[7] = 21;

	list.length = sizeof(list.info)/sizeof(*list.info);

	int item;
	bool found;

	cout << "Enter number to find in list: ";
	cin >> item;

	binarySearch(list, item, found);

	if (found)
		cout << item << " has been found in the list." << endl;

	else
		cout << item << " has not been found in the list." << endl;

	forgetfulBinarySearch(list, item, found);

	if (found)
		cout << item << " has been found in the list." << endl;

	else
		cout << item << " has not been found in the list." << endl;

	cout << 17 / 2 << endl;
}



