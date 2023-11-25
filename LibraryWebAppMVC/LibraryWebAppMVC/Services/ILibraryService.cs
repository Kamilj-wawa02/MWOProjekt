using LibraryWebAppMVC.Library;

namespace LibraryWebAppMVC.Services.LibraryService
{
    public interface ILibraryService
    {
        List<Book> GetBooks();

        bool UpdateBook(Book product);

        bool DeleteBook(int id);

        Book CreateBook(Book product);

        Book GetBookById(int id);
    }
}
