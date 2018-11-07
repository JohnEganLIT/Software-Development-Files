#include "stdafx.h"
#include "Book.h"

void option1();
void option2();
void option3();
void option4();
void option5();
void returnToMenu();

vector <CBook> books;

int main()
{
	cout << "---------------------" << endl;
	cout << "      Book Shop     " << endl;
	cout << "---------------------" << endl;
	cout << "1. Add book" << endl;
	cout << "2. Display books" << endl;
	cout << "3. Search by ISBN" << endl;
	cout << "4. Update book details" << endl;
	cout << "5. Delete book" << endl;
	cout << "6. Exit Application" << endl;

	int option;
	cout << "\nEnter option: ";
	cin >> option;

	switch (option)
	{
	case 1:
		system("CLS");
		option1();
		break;
	case 2:
		system("CLS");
		option2();
		break;
	case 3:
		system("CLS");
		option3();
		break;
	case 4:
		system("CLS");
		option4();
		break;
	case 5:
		system("CLS");
		option5();
		break;
	case 6:
		cout << "GoodBye" << endl;
		break;
	default:
		system("CLS");
		cout << "\nIncorrect Option!\n" << endl;
		main();
	}
	main();
}

void option1()
{
	cout << "----------------------" << endl;
	cout << "       Add Book       " << endl;
	cout << "----------------------" << endl;

	CBook book;
	book.getUserInput();
	books.push_back(book);

	returnToMenu();

}

void option2()
{
	cout << "----------------------" << endl;
	cout << "     Display Books    " << endl;
	cout << "----------------------" << endl;

	for (int i = 0; i < books.size(); i++)
	{
		CBook newBook = books[i];
		newBook.displayBooks();
		cout << "\n----------------------" << endl;
	}

	returnToMenu();
}

void option3()
{
	string isbn;

	cout << "----------------------" << endl;
	cout << "     Search Books     " << endl;
	cout << "----------------------" << endl;

	cout << "Enter ISBN: ";
	cin >> isbn;

	for (int i = 0; i < books.size(); i++)
	{
		CBook book = books[i];

		if (isbn == book.getISBN())
		{
			book.displayBooks();
		}

		else
		{
			cout << "No Books found" << endl;
			returnToMenu();
		}
	}

	returnToMenu();
}

void option4()
{
	string isbn;

	cout << "----------------------" << endl;
	cout << "     Update Books     " << endl;
	cout << "----------------------" << endl;

	cout << "Enter ISBN: ";
	cin >> isbn;
	cout << endl;

	for (int i = 0; i < books.size(); i++)
	{
		CBook book = books[i];

		if (isbn == book.getISBN())
		{
			book.getUserInput();
			books[i] = book;
		}

		else
		{
			cout << "\nNo Books found" << endl;
			returnToMenu();
		}
	}

	returnToMenu();
}

void option5()
{
	string isbn;

	cout << "----------------------" << endl;
	cout << "     Delete Books     " << endl;
	cout << "----------------------" << endl;

	cout << "Enter ISBN: ";
	cin >> isbn;
	cout << endl;

	for (int i = 0; i < books.size(); i++)
	{
		CBook book = books[i];

		if (isbn == book.getISBN())
		{
			books.erase(books.begin() + i);
		}

		else
		{
			cout << "No Books found" << endl;
			returnToMenu();
		}
	}

	returnToMenu();
}

void returnToMenu()
{
	cout << "\n----------------------" << endl;
	cout << "\n    Complete!" << endl;
	cout << "\n----------------------" << endl;
	system("PAUSE");
	system("CLS");
	main();
}
