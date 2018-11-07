template <class ItemType>
void RightBalance(TreeNode<ItemType> *& tree, bool & taller)
{
	TreeNode<ItemType> * rs = tree->right;
	TreeNode<ItemType> * ls;

	switch (rs->bf)
	{
	case RH:
		tree->bf = rs->bf = EH;
		RotateLeft(tree);
		taller = false;
		break;

	case EH:
		cerr << "Tree already balanced " << endl;
		break;

	case LH:
		ls = rs->left;
		switch (ls->bf)
		{
		case RH:	tree->bf = LH;
			rs->bf = EH;
			break;
		case EH:	tree->bf = rs->bf = EH;
			break;
		case LH:	tree->bf = EH;
			rs->bf = RH;
			break;
		}
	}
	ls->bf = EH;
	RotateRight(tree->right);
	RotateLeft(tree);
	taller = false;
}