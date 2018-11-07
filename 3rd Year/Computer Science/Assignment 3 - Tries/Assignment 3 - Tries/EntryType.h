#pragma once
#include "stdafx.h"
const int MAXLENGTH = 10;

class EntryType
{
public:
	EntryType();
	EntryType(char * key);
	EntryType(EntryType & entry);
	friend istream& operator >> (istream& is, EntryType& item);
	friend ostream& operator<< (ostream& os, EntryType item);
	bool operator== (const EntryType& item) const;
	bool operator!= (const EntryType& item) const;

private:
	char entryKey[MAXLENGTH];

};

EntryType::EntryType()
{

}

EntryType::EntryType(char * key)
{

}

EntryType::EntryType(EntryType & entry)
{

}


EntryType * TrieType::TrieSearch(Key target)
{
	int i;
	Trienode * current = root;
	for (i = 0; i < MAXLENGTH && current; i++)
		if (target[i] == '\0')
			break;
		else
			current = current->branch[target[i] - 'a'];
	
	if (!current)
		return NULL;
	else
		if (!current->ref)
			return NULL;

	return current->ref;
}

