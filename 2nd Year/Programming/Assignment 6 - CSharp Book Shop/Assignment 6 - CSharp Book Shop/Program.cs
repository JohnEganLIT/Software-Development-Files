using System;
using System.Collections.Generic;

namespace Bookshop
{
    class Program
    {
        static List<Book> bookList = new List<Book>();
 
        static void Main()
        {
            menu();    
        }

        static void menu()
        {
            bool exit = false;

            Console.WriteLine("1. Add books");
            Console.WriteLine("2. Display Books");
            Console.WriteLine("3. Search by ISBN");
            Console.WriteLine("4. Delete book details by ISBN");
            Console.WriteLine("5. Exit");

            try
            {
                Console.Write("\nEnter Option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        addBooks();
                        break;
                    case 2:
                        displayBooks();
                        break;
                    case 3:
                        searchBooks();
                        break;
                    case 4:
                        deleteBooks();
                        break;
                    case 5:
                        exit = true;
                        Console.Clear();
                        Console.WriteLine("------------");
                        Console.WriteLine(" Goodbye :) ");
                        Console.WriteLine("------------");
                        break;
                 }
            }

            catch
            {
                Console.WriteLine("\nEnter option 1,2,3,4 or 5.");
                pressAnyKey();
            }

            if(exit == false)
            Main();
        }

        static void addBooks()
        {
            Console.Clear();

            Book book = new Book();
            book.ISBN = "351";
            book.Author = "Daniel Malone";
            book.Title = "The Adventures of Daniel Malone";
            book.Price = 20.50;           
            bookList.Add(book);

            Book book2 = new Book();
            book2.ISBN = "142";
            book2.Author = "Jimmy Reilly";
            book2.Title = "The Life and Times of Jimmy";
            book2.Price = 10.75;
            bookList.Add(book2);

            Book book3 = new Book();
            book3.ISBN = "635";
            book3.Author = "Johton";
            book3.Title = "Talking about stuff";
            book3.Price = 0.50;
            bookList.Add(book3);

            Book book4 = new Book();
            book4.ISBN = "199";
            book4.Author = "Tommy Bookwriter";
            book4.Title = "Writing books with Tommy";
            book4.Price = 5.50;
            bookList.Add(book4);

            Book book5 = new Book();
            book5.ISBN = "326";
            book5.Author = "Mickey Ryan";
            book5.Title = "Piano for Dummies";
            book5.Price = 8.50;
            bookList.Add(book5);

            Book book6 = new Book();
            book6.ISBN = "997";
            book6.Author = "Amanda Reilly";
            book6.Title = "Buying Stuff";
            book6.Price = 7.25;
            bookList.Add(book6);

            Book book7 = new Book();
            book7.ISBN = "732";
            book7.Author = "Emily Emilius";
            book7.Title = "My Book";
            book7.Price = 20.25;
            bookList.Add(book7);

            Console.WriteLine("==========================");
            Console.WriteLine(" Books Added Successfully ");
            Console.WriteLine("==========================");

            pressAnyKey();
            return;
        }

        static void displayBooks()
        {
            Console.Clear();

            Console.WriteLine("1. Display books by ISBN");
            Console.WriteLine("2. Display books by Author");
            Console.WriteLine("3. Display books by Price");

            try
            {
                Console.Write("\nEnter Option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        bookList.Sort((x, y) => x.ISBN.CompareTo(y.ISBN));
                        break;

                    case 2:
                        bookList.Sort((x, y) => x.Author.CompareTo(y.Author));
                        break;

                    case 3:
                        bookList.Sort((x, y) => x.Price.CompareTo(y.Price));
                        break;

                    default:
                        Console.WriteLine("Incorrect Option!");
                        break;
                }

                Console.WriteLine("===============");
                Console.WriteLine(" List of Books ");
                Console.WriteLine("===============");

                foreach (Book book in bookList)
                {
                    Console.WriteLine("ISBN: {0}\nAuthor: {1}\nTitle: {2}\nPrice: ${3}\n", book.ISBN, book.Author, book.Title, book.Price);
                }

                pressAnyKey();
                return;
            } 
            
            catch
            {
                Console.WriteLine("Error! Enter option 1, 2 or 3.");
                pressAnyKey();
                return;
            }        
        }

        static void searchBooks()
        {
            Console.Clear();

            Console.WriteLine("================");
            Console.WriteLine(" Search By ISBN ");
            Console.WriteLine("================");

            try
            {
                Console.Write("\nEnter ISBN: ");
                string search = Console.ReadLine();

                foreach (Book book in bookList)
                {
                    if (search == book.ISBN)
                    {
                        Console.WriteLine("\nISBN: {0}\nAuthor: {1}\nTitle: {2}\nPrice: ${3}\n", book.ISBN, book.Author, book.Title, book.Price);
                        pressAnyKey();
                        return;
                    }
                }

                Console.WriteLine("Book Not Found!");
                pressAnyKey();
                return;
            }

            catch
            {
                Console.WriteLine("Error! Enter option 1, 2 or 3.");
                pressAnyKey();
                return;
            }
        }

        static void deleteBooks()
        {
            Console.Write("\nEnter ISBN: ");
            string search = Console.ReadLine();

            int counter = 0;
            bool bookFound = false;

            foreach(Book book in bookList)
            {
                if (search == book.ISBN)
                {
                    bookList.RemoveAt(counter);
                    Console.WriteLine("\nBook Deleted");
                    bookFound = true;
                    break;
                }

                counter++;
            }
            
            if(bookFound == false)
            {
                Console.WriteLine("Book Not Found");
            }

            pressAnyKey();
            return;
        }

        static void pressAnyKey()
        {          
            Console.WriteLine("\nPress Any Key To Return To Main Menu");          
            Console.ReadKey(false);
            Console.Clear();
        }
    }
}
