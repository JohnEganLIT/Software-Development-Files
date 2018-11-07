#include "stdafx.h"
#include "TreeType.h"

template <class ItemType>
TreeType<ItemType>::TreeType()
{
	root = NULL;
}

template <class ItemType>
TreeType<ItemType>::~TreeType()
{
	Destroy(root);
}

template<class ItemType>
TreeType<ItemType>::TreeType(const TreeType<ItemType> &originalTree)
{
}

template <class ItemType>
void TreeType<ItemType>::operator = (const TreeType<ItemType> &originalTree)
{
	
}

template <class ItemType>
void TreeType<ItemType>::MakeEmpty()
{
	Destroy(root);
	root = NULL;
}

template <class ItemType>
bool TreeType<ItemType>::IsEmpty() const
{
	return root == NULL;
}

template <class ItemType>
bool TreeType<ItemType>::IsFull() const
{
	TreeNode* location;
	try
	{
		location = new TreeNode;
		delete location;
		return false;
	}
}

template <class ItemType>
int TreeType<ItemType>::NumberOfNodes() const
{
	return CountNodes(root);
}

template <class ItemType>
void TreeType<ItemType>::RetrieveItem(ItemType &item, bool &found)
{
	Retrieve(root, item, found);
}

template <class ItemType>
void TreeType<ItemType>::InsertItem(ItemType item)
{
	insert(root, item);
}

template <class ItemType>
void TreeType<ItemType>::DeleteItem(ItemType item)
{
	Delete(root, item);
}

template <class ItemType>
void TreeType<ItemType>::PrintTree(ostream &outFile) const
{
	print(root, outFile);
}

  //==================//
 // Helper Functions //
//==================//

template<class ItemType>			     
int countNodes(TreeNode<ItemType> *tree)
{
	if (tree == NULL)
		return 0;
	else
		return CountNodes(tree->left) + CountNodes(tree->right) + 1;
}

template<class ItemType>			   
void Retrieve(TreeNode<ItemType>* tree, ItemType &item, bool& found)
{
	if (tree == NULL)
		found = false;	// item is not found.
	else if (item < tree->info)							// Search left subtree.
		Retrieve(tree->left, item, found);
	else if (item > tree->info) 							// Search right subtree.
		Retrieve(tree->right, item, found);
	else
	{				// item is found.
		item = tree->info;				found = true;
	}
}

template<class ItemType>			     
void Insert(TreeNode<ItemType>* &tree, ItemType item)
{
	if (tree == NULL)
	{			// Insertion place found.
		tree = new TreeNode<ItemType>;
		tree->right = NULL;
		tree->left = NULL;
		tree->info = item;
	}

	else if (item < tree->info)
		Insert(tree->left, item);      					// Insert in left subtree.
	else
		Insert(tree->right, item);     					// Insert in right subtree.
}

template<class ItemType>			     
void Delete(TreeNode<ItemType>* &tree, ItemType item)
{
	if (item < tree->info)
		Delete(tree->left, item);						  // Look in left subtree.
	else if (item > tree->info)
		Delete(tree->right, item);						  // Look in right subtree.
	else
		DeleteNode(tree);							  // Node found; call DeleteNode.
}

template<class ItemType>			    
void DeleteNode(TreeNode<ItemType>* &tree)
{
	TreeNode<ItemType>* tempPtr;

	tempPtr = tree;
	if (tree->left == NULL)
	{
		tree = tree->right;
		delete tempPtr;
	}
	else if (tree->right == NULL)
	{
		tree = tree->left;
		delete tempPtr;
	}
	else
	{
		GetPredecessor(tree->left, data);
		tree->info = data;
		Delete(tree->left, data);						// Delete predecessor node.
	}
}

template<class ItemType>			    
void GetPredecessor(TreeNode<ItemType>* tree, ItemType &data)
// Sets data to the info member of the right-most // node in tree.
{
	while (tree->right != NULL)
		tree = tree->right;
	data = tree->info;
}

template<class ItemType>	
void Print(TreeNode<ItemType>* tree, ofstream &outFile)
// Prints info member of items in tree in sorted // order on outFile.
{
	if (tree != NULL)
	{
		Print(tree->left, outFile);							// Print left subtree.
		outFile << tree->info;
		Print(tree->right, outFile);							// Print right subtree.
	}
}

template<class ItemType>
void InPrint(TreeNode<ItemType>* tree, ofstream &outFile)
// Prints info member of items in tree in sorted // order on outFile.
{
	if (tree != NULL)
	{
		InPrint(tree->left, outFile);							// Print left subtree.
		outFile << tree->info;
		InPrint(tree->right, outFile);						// Print right subtree.
	}
}

template<class ItemType>
void PrePrint(TreeNode<ItemType>* tree, ofstream &outFile)
// Prints info member of items in tree in sorted // order on outFile.
{
	if (tree != NULL)
	{
		outFile << tree->info;
		PrePrint(tree->left, outFile);						// Print left subtree.
		PrePrint(tree->right, outFile);						// Print right subtree.
	}
}

template<class ItemType>
void PostPrint(TreeNode<ItemType>* tree, ofstream &outFile)
// Prints info member of items in tree in sorted // order on outFile.
{
	if (tree != NULL)
	{
		PostPrint(tree->left, outFile);						// Print left subtree.
		PostPrint(tree->right, outFile);						// Print right subtree.
		outFile << tree->info;
	}
}

template<class ItemType>
void Destroy(TreeNode<ItemType>* &tree)
// Post: tree is empty; nodes have been deallocated.
{
	if (tree != NULL)
	{
		Destroy(tree->left);
		Destroy(tree->right);
		delete tree;
	}
}









