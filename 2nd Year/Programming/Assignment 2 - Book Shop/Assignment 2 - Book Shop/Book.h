#pragma once
class CBook
{
public:
	CBook();
	~CBook();

	void setISBN(string);
	void setAuthor(string);
	void setTitle(string);
	void setPrice(float);

	string getISBN() const;
	string getAuthor() const;
	string getTitle() const;
	float getPrice() const;

	void getUserInput();
	void displayBooks();
private:
	string ISBN;
	string Title;
	string Author;
	float Price;
};

