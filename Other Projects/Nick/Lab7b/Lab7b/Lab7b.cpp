#include "pch.h"
#include "Queue.h"

void menu()
{
	Queue<int> queue;
	int value;

	bool exit = false;
	while (!exit)
	{
		cout << endl;
		cout << "1. Enqueue" << endl;
		cout << "2. Dequeue" << endl;
		cout << "3. Get Count" << endl;
		cout << "4. Display" << endl;
		cout << "5. Exit Application" << endl;
		cout << "Enter Option: ";

		int option;
		cin >> option;

		switch (option)
		{
		case 1:
			cout << "Enter Value: ";
			cin >> value;
			queue.Enqueue(value);
			break;
		case 2:
			queue.Dequeue();
			break;
		case 3:
			cout << "\nThere are " << queue.GetCount() << " items in the queue." << endl;
			break;
		case 4:
			queue.Display();
			break;
		case 5:
			exit = true;
			break;
		default:
			cout << "Incorrect Option" << endl;
			break;
		}
	}
}

int main()
{
	menu();
}

