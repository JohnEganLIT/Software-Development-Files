// Binary Search Tree.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

struct Node
{
	int data;
	Node* left; 
	Node* right;
};

Node* getNewNode(int data)
{
	Node* newNode = new Node();

	newNode->data = data;

	return newNode;
}

Node* insert(Node* root, int data)
{
	if (root == NULL)
	{
		root = getNewNode(data);
		return root;
	}
}

int main()
{
	Node* root = NULL;

	root = insert(root, 15);
	root = insert(root, 23);
	root = insert(root, 7);
}

