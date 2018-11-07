#pragma once
class PQType
{
public:
	PQType(int);
	~PQType();

private:
	int numItems;
	//HeapType<ItemType> items;
	int maxItems;
};

