#pragma once
enum BalFactor { LH, RH, EH };

template <class ItemType>
struct TreeNode
{
	ItemType info;
	TreeNode<ItemType> *left;
	TreeNode<ItemType> *right;
	BalFactor bf;
};

template<typename ItemType>
class TreeType
{
	public:
		TreeType();
		void InsertItem(ItemType item);
		void PrintTree();
		void SearchTree(ItemType search);
		void DeleteItem(ItemType item);

	private:
		TreeNode<ItemType> *root;
};

template <class ItemType>
TreeType<ItemType>::TreeType()
{
	root = NULL;
}

template <class ItemType>
void TreeType<ItemType>::InsertItem(ItemType item) //Calls recursive function Delete
{
	bool taller = false;
	Insert(root, item, taller);
}

template <class ItemType>
void TreeType<ItemType>::PrintTree() //Calls recursive function Print
{
	Print(root);
	cout << "\n";
	system("PAUSE");
	system("CLS");
}

template <class ItemType>
void TreeType<ItemType>::SearchTree(ItemType item) //Calls recursive function Search
{
	if (!Search(root, item))
		cout << "\nItem not found!" << endl;
}

template <class ItemType>
void TreeType<ItemType>::DeleteItem(ItemType item) //Calls recursive function Delete
{
	bool shorter;
	Delete(root, item, shorter);
}

template <class ItemType>
void Insert(TreeNode<ItemType> *&tree, ItemType item, bool &taller) 
{
	if (tree == NULL)
	{	// Insertion place found.
		tree = new TreeNode<ItemType>;
		tree->left = NULL;
		tree->right = NULL;
		tree->info = item;
		tree->bf = EH;
		taller = true;
	}

	else if (item == tree->info)
		cout << "Duplicate key is not allowed in AVL tree." << endl;

	else if (item < tree->info)
	{
		Insert(tree->left, item, taller);  					
		if (taller)
		{
			switch (tree->bf)
			{
				case LH:
					LeftBalance(tree, taller);
					break;
				case EH:
					tree->bf = LH;
					break;
				case RH:
					tree->bf = EH;
					taller = false;
					break;
			}
		}
	}

	else
	{
		Insert(tree->right, item, taller);    

		switch (tree->bf)
		{
			case RH: 
				RightBalance(tree, taller); 
				break;
			case EH: 
				tree->bf = RH; 
				break;
			case LH: 
				tree->bf = EH;
				taller = false; 
				break;
		}
	}
}

template <class ItemType>
void RotateLeft(TreeNode<ItemType> *&tree)
{
	TreeNode<ItemType> *rs;
	if (tree == NULL)
		cout << "It is impossible to rotate an empty tree in RotateLeft" << endl;

	else if (tree->right == NULL)
		cout << "It is impossible to make an empty subtree the root in RotateLeft" << endl;

	else
	{
		rs = tree->right;
		tree->right = rs->left;
		rs->left = tree;
		tree = rs;
	}
}

template <class ItemType>
void RotateRight(TreeNode<ItemType> *&tree)
{
	TreeNode<ItemType> *ls;
	if (tree == NULL)
		cout << "It is impossible to rotate an empty tree in RotateRight" << endl;
	else if (tree->left == NULL)
		cout << "It is impossible to make an empty subtree the root in RotateRight" << endl;
	else
	{
		ls = tree->left;
		tree->left = ls->right;
		ls->right = tree;
		tree = ls;
	}
}

template <class ItemType>
void RightBalance(TreeNode<ItemType> *&tree, bool &taller)
{
	TreeNode<ItemType> *rs = tree->right;
	TreeNode<ItemType> *ls;

	switch (rs->bf)
	{
		case RH:
			tree->bf = rs->bf = EH;
			RotateLeft(tree);
			taller = false;
			break;
		case EH:
			cout << "Tree already balanced " << endl;
			break;
		case LH:
			ls = rs->left;

			switch (ls->bf)
			{
				case RH:    
					tree->bf = LH;
					rs->bf = EH;
					break;
				case EH:    
					tree->bf = rs->bf = EH;
					break;
				case LH:    
					tree->bf = EH;
					rs->bf = RH;
					break;
			}

			ls->bf = EH;
			RotateRight(tree->right);
			RotateLeft(tree);
			taller = false;
	}
}

template <class ItemType>
void LeftBalance(TreeNode<ItemType> *&tree, bool & taller)
{
	TreeNode<ItemType> *ls = tree->left;
	TreeNode<ItemType> *rs;

	switch (ls->bf)
	{
		case LH:
			tree->bf = ls->bf = EH;
			RotateRight(tree);
			taller = false;
			break;
		case EH:
			cout << "Tree already balanced " << endl;
			break;
		case RH:
			rs = ls->left;

			switch (rs->bf)
			{
				case LH:    tree->bf = RH;
					ls->bf = EH;
					break;
				case EH:    tree->bf = ls->bf = EH;
					break;
				case RH:    tree->bf = EH;
					ls->bf = LH;
					break;
			}

			rs->bf = EH;
			RotateLeft(tree->left);
			RotateRight(tree);
			taller = false;
	}
}

template <class ItemType>
void Print(TreeNode<ItemType> *tree)
{
	if (tree != NULL)
	{
		Print(tree->left);

		cout << "\n ===========================" << endl;
		cout << "    Item: " << tree->info << endl; 

		switch (tree->bf)
		{
			case LH:
				cout << "    Balance: Left High ";
				break;
			case RH:
				cout << "    Balance: Right High ";
				break;
			case EH:
				cout << "    Balance: Equal Height ";
				break;
		}

		if (tree->left != NULL)
			cout << "\n    Left: " << tree->left->info << endl;

		else
			cout << "\n    Left: Null" << endl;

		if (tree->right != NULL)
			cout << "    Right: " << tree->right->info << endl;

		else
			cout << "    Right: Null" << endl;

		cout << " ===========================" << endl;

		Print(tree->right);
	}
}

template <class ItemType>
bool Search(TreeNode<ItemType> *tree, ItemType item)
{
	if (tree != NULL)
	{
		if (Search(tree->left, item))
			return true;

		if (item == tree->info)
		{
			cout << "\n   Item \"" << tree->info << "\" found" << endl;

			cout << " ===========================" << endl;
			cout << "    Item: " << tree->info << endl;

			switch (tree->bf)
			{
			case LH:
				cout << "    Balance: Left High ";
				break;
			case RH:
				cout << "    Balance: Right High ";
				break;
			case EH:
				cout << "    Balance: Equal Height ";
				break;
			}

			if (tree->left != NULL)
				cout << "\n    Left: " << tree->left->info << endl;

			else
				cout << "\n    Left: Null" << endl;

			if (tree->right != NULL)
				cout << "    Right: " << tree->right->info << endl;

			else
				cout << "    Right: Null" << endl;

			cout << " ===========================" << endl;

			return true;
		}

		if (Search(tree->right, item))
			return true;
	}

	return false;
}

template <class ItemType>
void Delete(TreeNode<ItemType> *&tree, ItemType item, bool &shorter)
{
	if (tree != NULL)
	{
		if (item < tree->info)
		{
			Delete(tree->left, item, shorter);

			if (shorter)
				switch (tree->bf)
				{
					case LH:
						tree->bf = EH;
						break;
					case EH:
						tree->bf = RH; 
						shorter = false;
						break;
					case RH:
						DelRightBalance(tree, shorter);
				}
		}

		else if (item > tree->info)
		{
			Delete(tree->right, item, shorter);

			if (shorter)
				switch (tree->bf)
				{
				case LH:
					DelLeftBalance(tree, shorter);
					break;
				case EH:
					tree->bf = LH;
					shorter = false;
					break;
				case RH:
					tree->bf = EH;
					break;
				}
		}
		else
		{
			DeleteNode(tree, shorter);
			cout << "Item Deleted" << endl;
			cout << "\n";
			//system("PAUSE");
			//system("CLS");
		}
	}

	else
	{
		cout << "\nNOTE: " << item << " not in the tree so cannot be deleted.\n";
	}
}

template <class ItemType>
void DeleteNode(TreeNode <ItemType> * & tree, bool & shorter)
{
	ItemType data;
	TreeNode <ItemType> *tempPtr;
	tempPtr = tree;

	if (tree->left == NULL)
	{
		tree = tree->right;
		delete tempPtr;
		shorter = true;
	}

	else if (tree->right == NULL)
	{
		tree = tree->left;
		delete tempPtr;
		shorter = true;
	}

	else
	{
		GetPredecessor(tree, data);
		tree->info = data;
		Delete(tree->left, data, shorter);

		if (shorter)
		{
			switch (tree->bf)
			{
			case LH:
				tree->bf = EH;
				break;
			case EH: tree->bf = RH;
				shorter = false;
				break;
			case RH:
				DelRightBalance(tree, shorter);
			}
		}
	}
}

template <class ItemType>
void GetPredecessor(TreeNode<ItemType> *tree, ItemType &data)
{
	tree = tree->left;
	while (tree->right != NULL)
		tree = tree->right;
	data = tree->info;
}

template <class ItemType>
void DelRightBalance(TreeNode<ItemType> *tree, bool &shorter)
{
	TreeNode<ItemType> *rs = tree->right;
	TreeNode<ItemType> *ls;

	switch (rs->bf)
	{
		case RH:	
			tree->bf = rs->bf = EH;
			RotateLeft(tree);
			shorter = true; 
			break;
		case EH:	
			tree->bf = RH;
			rs->bf = LH;
			RotateLeft(tree);
			shorter = false; 
			break;
		case LH:	
			ls = rs->left;
			switch (ls->bf)
			{
				case RH:	
					tree->bf = LH;
					rs->bf = EH; 
					break;
				case EH:	
					tree->bf = rs->bf = EH;
					break;
				case LH:	
					tree->bf = EH;
					rs->bf = RH; 
					break;
			} 

		ls->bf = EH;
		RotateRight(tree->right);
		RotateLeft(tree);
		shorter = true;
	}
}

template <class ItemType>
void DelLeftBalance(TreeNode<ItemType> *&tree, bool &shorter)
{
	TreeNode<ItemType> *ls = tree->left;
	TreeNode<ItemType> *rs;

	switch (ls->bf)
	{
		case LH:	
			tree->bf = ls->bf = EH;
			RotateRight(tree);
			shorter = true; break;
		case EH:	
			tree->bf = LH;
			ls->bf = RH;
			RotateRight(tree);
			shorter = false; break;
		case RH:	
			rs = ls->right;
			switch (rs->bf)
			{
				case LH:	
					tree->bf = RH;
					ls->bf = EH; 
					break;
				case EH:	
					tree->bf = ls->bf = EH;
					break;
				case RH:	
					tree->bf = EH;
					ls->bf = LH; 
					break;
			} 

		rs->bf = EH;
		RotateLeft(tree->left);
		RotateRight(tree);
		shorter = true;
	}
}