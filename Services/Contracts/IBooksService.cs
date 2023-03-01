namespace BookDepot.Services.Contracts;

using BookDepot.Data.Models;
using BookDepot.Models.Books;

public interface IBooksService
{
    List<Book> GetAllBooks();
}
