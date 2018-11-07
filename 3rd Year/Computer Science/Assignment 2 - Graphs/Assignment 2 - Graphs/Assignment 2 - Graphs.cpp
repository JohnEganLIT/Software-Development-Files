#include "stdafx.h"
#include "Graph.h"

using namespace std; 

void Pause()
{
	system("PAUSE");
	system("CLS");
}

string formatString(string value)
{
	for (int i = 0; i < value.size(); i++)
	{
		value[i] = toupper(value[i]);
	}

	return value;
}

void CreateFlight(FlightsGraph &graph)
{
	system("CLS");
	cout << "------------------------------------" << endl;
	cout << "         Create Flight" << endl;
	cout << "------------------------------------" << endl;
	string departure, arrival;
	int distance;

	cout << "Enter Departure Airport: ";
	cin >> departure;

	cout << "Enter Arrival Airport: ";
	cin >> arrival;

	cout << "Enter Distance(km): ";
	cin >> distance;

	while (cin.fail())
	{
		cin.clear();
		cin.ignore(numeric_limits<std::streamsize>::max(), '\n');
		cout << "Value must be a number" << endl;
		cout << "Enter Distance: ";
		cin >> distance;
	}

	departure = formatString(departure);
	arrival = formatString(arrival);

	graph.AddVertex(departure);
	graph.AddVertex(arrival);
	graph.AddEdge(departure, arrival, distance);

	Pause();
}

void DisplayFlights(FlightsGraph &graph)
{
	system("CLS");
	cout << "------------------------------------" << endl;
	cout << "       List of Flights" << endl;
	cout << "------------------------------------" << endl;
	graph.print();
	Pause();
}

void SeekFlight(FlightsGraph &graph)
{
	string departure, arrival;

	cout << "Enter Departure Airport: ";
	cin >> departure;

	cout << "Enter Arrival Airport: ";
	cin >> arrival;

	departure = formatString(departure);
	arrival = formatString(arrival);

	graph.SeekPath(departure, arrival);

	Pause();
}

void DeleteFlight(FlightsGraph &graph)
{
	string departure, arrival;

	cout << "Enter Departure Airport: ";
	cin >> departure;

	cout << "Enter Arrival Airport: ";
	cin >> arrival;

	departure = formatString(departure);
	arrival = formatString(arrival);

	graph.DeleteEdge(departure, arrival);
	Pause();
}

int main()
{
	FlightsGraph graph;

	bool exit = false;

	while (!exit)
	{
		cout << "1. Create Flight" << endl;
		cout << "2. Display All Flights" << endl;
		cout << "3. Seek Flight" << endl;
		cout << "4. Delete Flight" << endl;
		cout << "5. Exit Application" << endl;
		cout << "Enter Option: ";

		int option;
		cin >> option;

		switch (option)
		{
			case 1:
				CreateFlight(graph);
				break;
			case 2:
				DisplayFlights(graph);
				break;
			case 3:
				SeekFlight(graph);
				break;
			case 4:
				DeleteFlight(graph);
				break;
			case 5:
				cout << "\nGoodbye :)" << endl;
				exit = true;
				break;
			default:
				cout << "Incorrect Option" << endl;
				break;
		}
	}
}


