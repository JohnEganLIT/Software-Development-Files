#pragma once
#include "stdafx.h"
using namespace std;

class FlightsGraph
{
	public:
		FlightsGraph();
		~FlightsGraph();

		void AddVertex(string);
		void AddEdge(string, string, int);
		int WeightIs(string, string);
		void SeekPath(string, string);
		void print();
		void MakeEmpty();
		void DeleteEdge(string, string);

	private:
		void RecursiveSearch(int, int, int);
		void printPath(int);
		void AddToPath(string);
		int IndexIs(string);
		int numVertices;
		int maxVertices;
		string *vertices;
		int edges[50][50];
		vector<string> *path;
};

FlightsGraph::FlightsGraph()
{
	numVertices = 5;
	maxVertices = 50;
	vertices = new string[50];
	path = new vector<string>;

	vertices[0] = "PARIS";
	vertices[1] = "DUBLIN";
	vertices[2] = "LONDON";
	vertices[3] = "MADRID";
	vertices[4] = "BERLIN";

	edges[0][1] = 200;
	edges[1][2] = 300;
	edges[1][3] = 400;
	edges[2][3] = 500;
	edges[3][4] = 600;
}

FlightsGraph::~FlightsGraph()
{
	delete vertices;
	delete path;
}

void FlightsGraph::AddVertex(string vertex)
{	
	bool vertexFound = false;
	
	//Checks if vertex already exists
	for (int index = 0; index < numVertices; index++)
	{
		if (vertices[index] == vertex)
			vertexFound = true;
	}
	
	//Adds vertex
	if (vertexFound == false)
	{
		vertices[numVertices] = vertex;

		for (int index = 0; index<numVertices; index++)
		{
			edges[numVertices][index] = 0; //Null Edge
			edges[index][numVertices] = 0; //Null Edge
		}
		numVertices++;
	}		
}

void FlightsGraph::AddEdge(string fromVertex, string toVertex, int weight)
{
	int row = IndexIs(fromVertex);
	int col = IndexIs(toVertex);

	edges[IndexIs(fromVertex)][IndexIs(toVertex)] = weight;
}

void FlightsGraph::DeleteEdge(string fromVertex, string toVertex)
{
	int fromIndex = IndexIs(fromVertex);
	int toIndex = IndexIs(toVertex);

	edges[fromIndex][toIndex] = 0;

	bool foundTo = false;
	bool foundFrom = false;

	for (int i = 0; i < numVertices; i++)
	{
		if (edges[fromIndex][i] != 0)
		{
			foundFrom = true;
		}

		if (edges[toIndex][i] != 0)
		{
			foundTo = true;
		}
	}
}

void FlightsGraph::SeekPath(string fromVertex, string toVertex)
{
	int fromIndex = IndexIs(fromVertex);
	int toIndex = IndexIs(toVertex);

	RecursiveSearch(fromIndex, toIndex, 0);
}

void FlightsGraph::RecursiveSearch(int fromIndex, int toIndex, int distance)
{	
	//Pushes departure location onto vector
	if (path->empty())
	{
		path->push_back(vertices[fromIndex]);
	}

	//Checks for dead ends
	if (fromIndex >= numVertices)
	{
		path->pop_back();
		return;
	}
	
	//Checks if there is a direct path from current node to final node
	else if (edges[fromIndex][toIndex] != 0)
	{
		distance += edges[fromIndex][toIndex];
		AddToPath(vertices[toIndex]);
		printPath(distance);
		return;
	}

	//Checks all rows for an edge
	else
	{
		for (int col = 0; col < numVertices; col++)
		{
			if (edges[fromIndex][col] != 0)
			{
				AddToPath(vertices[col]);
				//distance += edges[fromIndex][toIndex];
				cout << distance << endl;
				RecursiveSearch(col, toIndex, distance + edges[fromIndex][toIndex]);
			}
		}
	}
}

void FlightsGraph::AddToPath(string value)
{
	bool found = false;

	for (int i = 0; i < path->size(); i++)
	{
		if (path->at(i) == value)
			found = true;
	}

	if (found == false)
		path->push_back(value);
}

void FlightsGraph::printPath(int distance)
{
	for (int i = 0; i < path->size(); i++)
	{
		if (i < path->size() - 1)
		{
			cout << path->at(i) << "->";
		}

		else
		{
			cout << path->at(i);
		}
	}
	
	cout << " = " << distance << " KM" << endl;
}

void FlightsGraph::print()
{
	for (int row = 0; row<numVertices; row++)
	{
		for (int col = 0; col < numVertices; col++)
		{
			if (edges[row][col] != 0)
			{
				cout << vertices[row] << " -> " << vertices[col] << " | Distance = " << edges[row][col] << "km";
				cout << "\n";
			}
		}
	}
}

int FlightsGraph::WeightIs(string fromVertex, string toVertex)
{
	return edges[IndexIs(fromVertex)][IndexIs(toVertex)];
}

int FlightsGraph::IndexIs(string vertex)
{
	int index = 0;
	while (!(vertex == vertices[index]))
		index++;
	return index;
}

void FlightsGraph::MakeEmpty()
{
	for (int index = 0; index<numVertices; index++)
	{
		edges[numVertices][index] = 0;
		edges[index][numVertices] = 0;
	}
}







