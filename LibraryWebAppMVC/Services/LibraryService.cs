
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using LibraryWebAppMVC.Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LibraryWebAppMVC.Repositories;

namespace LibraryWebAppMVC.Services.LibraryService
{
    public class LibraryService : ILibraryService
    {

        BookRepository bookRepository;

        public LibraryService(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Book CreateBook(Book book)
        {
            return bookRepository.Create(book);
        }

        public bool DeleteBook(int id)
        {
            return bookRepository.Delete(id);
        }

        public List<Book> GetBooks()
        {
            return bookRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return bookRepository.GetById(id);
        }


        public bool UpdateBook(Book book)
        {
            return bookRepository.Update(book.Id, book);
        }
    }
}
