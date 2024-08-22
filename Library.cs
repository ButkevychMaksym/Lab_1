using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Models
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public bool RemoveBook(string isbn)
        {
            var book = books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                books.Remove(book);
                return true;
            }
            return false;
        }

        public List<Book> SearchByAuthor(string author)
        {
            return books.Where(b => b.Author.IndexOf(author, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public List<Book> SearchByTitle(string title)
        {
            return books.Where(b => b.Title.IndexOf(title, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }
    }
}
