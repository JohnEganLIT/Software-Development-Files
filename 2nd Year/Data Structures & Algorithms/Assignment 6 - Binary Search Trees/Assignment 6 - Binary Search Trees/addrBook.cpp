#include "stdafx.h"
#include "addrBook.h"


addrBook::addrBook()
{
	root = NULL;
}

addrBook::~addrBook()
{
}

addrBook::node* addrBook::insert(int key)
{
	node* n = new node;
	n->number = key;
	n->left = NULL;
}
