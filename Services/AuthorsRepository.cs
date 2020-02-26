using System.Collections.Generic;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{

    public class AuthorsRepository : IAuthorsRepository
    {
        private Dictionary<int, Author> authors;
        public AuthorsRepository()
        {
            authors = new Dictionary<int, Author>();

            new List<Author>{
                new Author{Name="J.K Rowling"},
                new Author{Name="Margaret Atwood"},
                new Author{Name="Ursula Le Guin"},
            }.ForEach(a => this.AddAuthor(a));
        }
        public int AddAuthor(Author author)
        {
            if (author.Id == 0)
            {
                int key = authors.Count;
                while (authors.ContainsKey(key))
                {
                    key++;
                }
                author.Id = key;
            }
            authors[author.Id] = author;
            return author.Id;
        }

        public void DeleteAuthor(Author author)
        {
            throw new System.NotImplementedException();
        }

        public Author GetAuthor(int authorId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Author> GetAuthors()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAuthor(Author author)
        {
            throw new System.NotImplementedException();
        }
    }
}