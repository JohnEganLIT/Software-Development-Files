#pragma once
class addrBook
{
private:
	struct node
	{
		int number;
		//string firstName; 
		//string lastName;
		node* left;
		node* right;
	};

	node* root;

public:
	addrBook();
	~addrBook();

	node* insert(int number);
};


