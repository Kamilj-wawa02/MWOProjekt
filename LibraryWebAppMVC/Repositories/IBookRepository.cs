using LibraryWebAppMVC.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWebAppMVC.Repositories
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book GetById(int id);
        bool Update(int id, Book updatedBook);
        bool Delete(int id);
    }
}