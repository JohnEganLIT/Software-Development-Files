using System;

namespace Bookshop
{
    public class Book : IComparable<Book>
    {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public int CompareTo(Book obj)
        {
            /*
            return string.Compare(this.ISBN, obj.ISBN);
            */
            return string.Compare(this.Author, obj.Author);
            
        }
    }
}