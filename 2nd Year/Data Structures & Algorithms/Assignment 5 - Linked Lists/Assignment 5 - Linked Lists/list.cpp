#include "stdafx.h"
#include "list.h"

list::list()
{
	front = NULL;
	current = NULL;
}

void list::addNode(string addData)
{
	node* n = new node;
	n->next = NULL;
	n->data = addData;

	if (front != NULL)
	{
		current = front;
		while (current->next != NULL)
		{
			current = current->next;
		}
		current->next = n;
	}

	else
	{
		front = n;
	}
}

void list::print()
{
	cout << "Hello There" << endl;
	current = front;
	while (current = NULL)
	{
		cout << "Hi" << endl;
		cout << current->data << endl;
		current = current->next;
	}
}
