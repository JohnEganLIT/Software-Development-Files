#include "stdafx.h"
#include "Book.h"

CBook::CBook()
{

}

CBook::~CBook()
{

}

void CBook::setISBN(string isbn)
{
	ISBN = isbn;
}

void CBook::setTitle(string title)
{
	Title = title;
}

void CBook::setAuthor(string author)
{
	Author = author;
}

void CBook::setPrice(float price)
{
	Price = price;
}

string CBook::getISBN() const
{
	return ISBN;
}

string CBook::getTitle() const
{
	return Title;
}

string CBook::getAuthor() const
{
	return Author;
}

float CBook::getPrice() const
{
	return Price;
}

void CBook::getUserInput()
{
	cout << "Enter ISBN: ";
	cin >> ISBN;

	cout << "Enter Title: ";
	cin >> Title;

	cout << "Enter Price: ";
	cin >> Price;

	cout << "Enter Author: ";
	cin >> Author;
}

void CBook::displayBooks()
{
	cout << "\nISBN: " << ISBN << endl;
	cout << "\nTitle: " << Title << endl;
	cout << "\nAuthor: " << Author << endl;
	cout << "\nPrice: " << Price << endl;
}

