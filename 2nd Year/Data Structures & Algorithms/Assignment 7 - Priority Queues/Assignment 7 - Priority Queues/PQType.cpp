#include "stdafx.h"
#include "PQType.h"

template<class ItemType>
PQType<ItemType>::PQType(int max)
{
	maxItems = max;
	items.elements = new ItemType[max];
	numItems = 0;
}

template<class ItemType>
PQType<ItemType>::~PQType()
{
	delete[] items.elements;
}

template<class ItemType>
void PQType<ItemType>::MakeEmpty()
{
	numItems = 0;
}

template<class ItemType>
PQType<ItemType>::~PQType()
{
	delete[] items.elements;
}

template<class ItemType>
void PQType<ItemType>::MakeEmpty()
{
	numItems = 0;
}

template<class ItemType>
void PQType<ItemType>::Enqueue(ItemType newItem)
// Post: newItem is in the queue.
{
	numItems++;
	items.elements[numItems - 1] = newItem;
	items.ReheapUp(0, numItems - 1);
}

template<class ItemType>
void PQType<ItemType>::Dequeue(ItemType& item)
// Post: element with highest priority has been  // removed from the queue; a copy is returned in // item.
{
	item = items.elements[0];
	items.elements[0] = items.elements[numItems - 1];
	numItems--;
	items.ReheapDown(0, numItems - 1);
}

template<class ItemType>			     void PQType<ItemType>::RemoveItem(ItemType& item, int index)
// Post: element at index has been removed from  // the queue; a copy is returned in item.
{
	item = items.elements[index];
	items.elements[index] = items.elements[numItems - 1];
	numItems--;
	if (items.elements[index] < item)
		items.ReheapDown(index, numItems - 1);
	else
		items.ReheapUp(0, index);
}

