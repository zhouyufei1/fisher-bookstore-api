using System.Collections.Generic;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{

    public class BooksRepository : IBooksRepository
    {
        private Dictionary<int, Book> books;

        public BooksRepository()
        {
            books = new Dictionary<int, Book>();
            new List<Book>
            {
                new Book{Title="A Wizard of Earthsea"},
                new Book{Title="The Dispossessed"},
                new Book{Title="The Handmaid's Tale"},
                new Book{Title="Cat's Eye"},
                new Book{Title="Harry Potter and the Goblet of Fire"},
                new Book{Title="Harry Potter and the Half-Blood Prince"},
            }.ForEach(b => AddBook(b));
        }
        public int AddBook(Book book)
        {
            if (book.Id == 0)
            {
                int key = books.Count;
                while (books.ContainsKey(key))
                {
                    key++;
                }
                book.Id = key;
            }
            books[book.Id] = book;
            return book.Id;
        }

        public void DeleteBook(Book book)
        {
            throw new System.NotImplementedException();
        }

        public Author GetBook(int booksId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Author> GetBooks()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}