namespace RainingCatsAndDogsOnWeb.Web.Controllers
{
    using BookDepot.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BooksScraperController : Controller
    {
        private readonly IBooksScraperService booksScraperService;

        public BooksScraperController(IBooksScraperService booksScraperService)
        {
            this.booksScraperService = booksScraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Load()
        {
            await this.booksScraperService.PopulateDbWithBooks();

            return this.RedirectToAction("Index", "Home");
        }
    }
}
