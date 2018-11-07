// Assignment 3 - Tries.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "TrieType.h"

using namespace std;

int main()
{
	TrieType trie;

	bool exit = false;

	while (!exit)
	{
		cout << "1. Insert Word" << endl;
		cout << "2. Delete Word" << endl;
		cout << "3. Print Trie" << endl;
		cout << "4. Exit Application" << endl;
		cout << "Enter Option: ";

		int option;
		cin >> option;

		switch (option)
		{
		case 1:
			Insert(trie);
			break;
		case 2:
			Delete(trie);
			break;
		case 3:
			Print(trie);
			break;
		case 4:
			cout << "\nGoodbye :)" << endl;
			exit = true;
			break;
		default:
			cout << "Incorrect Option" << endl;
			break;
		}
	}
}

void Insert(TrieType &trie)
{
	system("CLS");

	string word; 
	cout << "Enter word: " << endl; 
	cin >> word;

	trie.InsertTrie(word);


}

void Delete(TrieType &trie)
{

}

void Print(TrieType &trie)
{

}

