#pragma once
class list
{
private:
	struct node {
		string data;
		node* next;
	};

	node* front;
	node* current;

public:
	list();
	void addNode(string addData);
	void print();
};

