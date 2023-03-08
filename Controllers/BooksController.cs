namespace BookDepot.Controllers;

using BookDepot.Models.Books;
using BookDepot.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

public class BooksController : Controller
{
    private readonly IBooksService booksService;

    public BooksController(IBooksService booksService)
    {
        this.booksService = booksService;
    }

    public IActionResult All()
    {
        var viewModel = new BooksListViewModel()
        {
            AllBooks = this.booksService.GetAllBooks()
        };

        return View(viewModel);
    }
}
