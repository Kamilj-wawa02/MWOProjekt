using LibraryWebAppMVC.Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebAppMVC.Repositories
{
    public class BookRepository : IBookRepository
    {
        Dictionary<int, Book> books = new Dictionary<int, Book>();
        int nextBookId = 1;

        public BookRepository() 
        {
            //this.books = new Dictionary<int, Book>();
        }

        public BookRepository(List<Book> books) 
        {
            //this.books = new Dictionary<int, Book>();
            Debug.WriteLine("Initializing!!!");
            for (int i = 0; i < books.Count; i++)
            {
                this.books.Add(books[i].Id, books[i]);
                nextBookId++;
            }
        }

        public Book Create(Book book)
        {
            Debug.WriteLine("Create");
            Debug.WriteLine(string.Join(", ", books.Values));
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            book.Id = nextBookId++;
            books.Add(book.Id, book);
            
            Debug.WriteLine(string.Join(", ", books.Values));

            return book;
        }

        public Book GetById(int id)
        {
            Debug.WriteLine("Get");
            if (books.TryGetValue(id, out var book))
            {
                return book;
            }
            return null;
        }

        public List<Book> GetAll()
        {
            Debug.WriteLine("GetAll");
            Debug.WriteLine(string.Join(", ", books.Values));
            return books.Values.ToList();
        }

        public bool Update(int id, Book updatedBook)
        {
            Debug.WriteLine("Update");
            Debug.WriteLine(string.Join(", ", books.Values));
            if (books.TryGetValue(id, out var existingBook))
            {
                existingBook.Title = updatedBook.Title;
                existingBook.Author = updatedBook.Author;
                existingBook.Description = updatedBook.Description;
                Debug.WriteLine(string.Join(", ", books.Values));
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            Debug.WriteLine("Delete");
            Debug.WriteLine(string.Join(", ", books.Values));
            if (books.ContainsKey(id))
            {
                books.Remove(id);
                Debug.WriteLine(string.Join(", ", books.Values));
                GetAll();
                return true;
            }
            Debug.WriteLine("Delete failed!");
            return false;
        }
    }
}