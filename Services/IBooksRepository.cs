using System.Collections.Generic;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{
    public interface IBooksRepository
    {
        IEnumerable<Author> GetBooks();
        Author GetBook(int booksId);
        int AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}