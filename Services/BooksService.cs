namespace BookDepot.Services;

using BookDepot.Data;
using BookDepot.Data.Models;
using BookDepot.Models.Books;
using BookDepot.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

public class BooksService : IBooksService
{
    private readonly ApplicationDbContext data;

    public BooksService(ApplicationDbContext data)
    {
        this.data = data;
    }

    public List<Book> GetAllBooks()
    {
        var allBooks = this.data.Books.OrderByDescending(x => x.Id)
                                    .ToList();

        return allBooks;
    }
}
