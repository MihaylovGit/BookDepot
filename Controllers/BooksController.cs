namespace BookDepot.Controllers;

using BookDepot.Models.Books;
using Microsoft.AspNetCore.Mvc;

public class BooksController : Controller
{
    public IActionResult All(BookListViewModel inputModel)
    {
        return this.View();
    }
}
