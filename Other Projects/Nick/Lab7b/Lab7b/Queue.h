#pragma once
#include <vector>

template <class T>
class Queue
{
private:
	vector<T> queue;

public:
	Queue();
	~Queue();
	void Enqueue(T item);
	void Dequeue();
	int GetCount();
	void Display();
};

template <class T>
Queue<T>::Queue()
{
}

template <class T>
Queue<T>::~Queue()
{
}

template <class T>
void Queue<T>::Enqueue(T item)
{
	queue.push_back(item);
}

template <class T>
void Queue<T>::Dequeue()
{
	queue.erase(queue.begin());
}

template <class T>
int Queue<T>::GetCount()
{
	return queue.size();
}

template <class T>
void Queue<T>::Display()
{
	cout << endl;
	for (int i = 0; i < queue.size(); i++)
	{
		cout << i << ". " << queue[i] << endl;
	}
	cout << endl;
}

