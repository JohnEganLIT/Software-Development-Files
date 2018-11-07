#pragma once

template <class ItemType>
struct TreeNode
{
	ItemType info;
	TreeNode* left;
	TreeNode* right;
};

template <class ItemType>
class TreeType
{
	public:
		TreeType();
		~TreeType();

		TreeType(const TreeType <ItemType> &originalTree);
		void operator=(const TreeType<ItemType> &originalTree);
		void MakeEmpty();
		bool IsEmpty() const;
		bool IsFull() const;
		int NumberOfNodes() const;

		void RetrieveItem(ItemType &item, bool &found);
		void InsertItem(ItemType item);
		void DeleteItem(ItemType item);
		void PrintTree(ostream &outFile) const;

	private:
		TreeNode<ItemType> *root;

};

