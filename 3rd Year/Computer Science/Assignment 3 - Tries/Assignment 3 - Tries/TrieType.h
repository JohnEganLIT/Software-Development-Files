#pragma once
#include "EntryType.h"
#include "stdafx.h"
const int LETTERS = 26;
typedef char Key[MAXLENGTH];

struct Trienode
{
	Trienode *branch[LETTERS];
	EntryType *ref;
};

class TrieType
{
public:
	TrieType();
	TrieType(TrieType &originalTree);
	~TrieType();
	
	void InsertTrie(Key newkey, EntryType *newentry);
	EntryType *TrieSearch(Key target);
	void operator=(TrieType &originalTree);
	bool DeleteTrie(Key delkey);
	void PrintTrie(ostream& outfile) const;
	void MakeEmpty();
private:
	Trienode * root;
};

TrieType::TrieType()
{
}

TrieType::TrieType(TrieType &originalTree)
{
}

TrieType::~TrieType()
{
}

void TrieType::InsertTrie(Key newkey, EntryType *newentry)
{
	int i;
	Trienode *current;

	if (!root)
		root = CreateNode();

	current = root;
	for (i = 0; i < MAXLENGTH; i++)
		if (newkey[i] == '\0')
			break;
		else
		{
			if (!current->branch[newkey[i] - 'a'])
				current->branch[newkey[i] - 'a'] = CreateNode();
			current = current->branch[newkey[i] - 'a'];
		}
	if (current->ref != NULL)
		cout << "\nTried to insert a duplicate key." << endl;
	else
		current->ref = newentry;

}

EntryType * TrieType::TrieSearch(Key target)
{
	int i;
	Trienode * current = root;

	for (i = 0; i < MAXLENGTH && current; i++)
		if (target[i] == '\0')
			break;
		else
			current =
			current->branch[target[i] - 'a'];

	if (!current)
		return NULL;
	else
		if (!current->ref)
			return NULL;

	return current->ref;
}


Trienode *CreateNode()
{
	int ch;
	Trienode *newnode = new Trienode;
	for (ch = 0; ch < LETTERS; ch++)
		newnode->branch[ch] = NULL;

	newnode->ref = NULL;

	return newnode;
}




