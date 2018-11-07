#pragma once

template <class ItemType>
class LinkedList
{
	public:

		struct Node;

		LinkedList();
		~LinkedList();

		bool isFull() const;
		int lengthIs() const;
		void makeEmpty();
		void retrieveItem(ItemType& item, bool& found);
		void insertItem(ItemType item);
		void deleteItem(ItemType item);
		void resetList();
		void getNextItem(ItemType&);
	private: 
		Node<ItemType>* listData;
		int length;
		Node<ItemType>* currentPos;

};

