#include "stdafx.h"
#include "LinkedList.h"

template<class ItemType>
struct Node
{
	ItemType info;
	Node<ItemType>* next;
};

template <class ItemType>
LinkedList::LinkedList()
{
	length = 0;
	listData = NULL;
}

template <class ItemType>
LinkedList::~LinkedList()
{
	Node<ItemType>* tempPtr;
	while (listData != NULL)
	{
		tempPtr = listData;
		listData = listData->next;
		delete tempPtr;
	}
	length = 0;

}

template<class ItemType>
bool LinkedList<ItemType>::isFull() const
{
	Node<ItemType>* ptr;
	ptr = new Node<ItemType>;
	if (ptr == NULL)
		return true;
	else
	{
		delete ptr;
		return false;
	}

}

template<class ItemType>
int LinkedList<ItemType>::lengthIs() const
{
	return length;
}

template<class ItemType>
void LinkedList<ItemType>::makeEmpty()
{
	Node<ItemType>* tempPtr;
	while (listData != NULL)
	{
		tempPtr = listData;
		listData = listData->next;
		delete tempPtr;
	}
	length = 0;

}

template <class ItemType>
void LinkedList<ItemType>::retrieveItem(ItemType& item, bool& found)
{
	bool moreToSearch;
	Node<ItemType>* location;
	location = listData;
	found = false;
	moreToSearch = (location != NULL);
	while (moreToSearch && !found)
	{
		if (item == location->info)
		{
			found = true;
			item = location->info;
		}
		else
		{
			location = location->next;
			moreToSearch = (location != NULL);
		}
	}
}

template <class ItemType>
void LinkedList<ItemType>::insertItem(ItemType item)
{
	Node<ItemType>* location;
	location = new Node<ItemType>;
	location->info = item;
	location->next = listData;
	listData = location;
	length++;
}

template <class ItemType>
void LinkedList<ItemType>::deleteItem(ItemType item)
{
	Node<ItemType>* location = listData;
	Node<ItemType>* tempLocation;
	// Locate node to be deleted.
	if (item == listData->info)
	{
		tempLocation = location;
		listData = listData->next;
		// Delete first node.
	}
	else
	{
		while (!(item == (location->next)->info))
			location = location->next;
		// Delete node at location->next
		tempLocation = location->next;
		location->next = (location->next)->next;
	}
	delete tempLocation;
	length--;
}

template <class ItemType>
void LinkedList<ItemType>::resetList()
{
	currentPos = NULL;
}

template <class ItemType>
void LinkedList<ItemType>::getNextItem(ItemType& item)
{
	if (currentPos == NULL)
		currentPos = listData;
	else
		currentPos = currentPos->next;
	item = currentPos->info;
}

template <class ItemType>
void LinkedList<ItemType>::display(Node* head)
{
	Node* temp = head;

	cout << "List is:" << endl;

	while (temp != NULL)
	{
		cout << temp->data << " ";
		temp = temp->next;
	}

	cout << "\n";
}