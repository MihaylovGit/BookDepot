namespace BookDepot.Services
{
    using AngleSharp;
    using BookDepot.Data;
    using BookDepot.Data.Models;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    public class BooksScraperService : IBooksScraperService
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;
        private readonly ApplicationDbContext booksData;

        public BooksScraperService(ApplicationDbContext booksData)
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
            this.booksData = booksData;
        }

        public async Task PopulateDbWithAds()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://www.orangecenter.bg/knizharnitsa/hudozhestvena-literatura?product_list_limit=120";
            int pages = 50;
            long isbn = 9789542841000;
            var context = BrowsingContext.New(config);

            var titleSelector = "product-item-name";
            var authorSelector = "product-item-subname";
            var priceSelector = "price";
            var imageSelector = "product-image-photo";

            var document = await context.OpenAsync(address);
            if (document.StatusCode == HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException();
            }

            var titleElements = document.GetElementsByClassName(titleSelector).Select(x => x.TextContent).ToList();
            var authorElements = document.GetElementsByClassName(authorSelector).Select(x => x.TextContent).ToList();
            var priceElements = document.GetElementsByClassName(priceSelector).Select(x => x.TextContent).ToList();
            var imageElements = document.GetElementsByClassName(imageSelector).Select(x => x.TextContent).ToList();

            var books = new List<Book>();

            for (int i = 1; i < titleElements.Count; i++)
            {
                if (document.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new InvalidOperationException();
                }

                var author = new Author
                {
                    Name = authorElements[i],
                };

                var category = new Category
                {
                    Genre = Genre.Classics,
                };

                var currentBook = new Book
                {
                    Title = titleElements[i],
                    ImageUrl = imageElements[i],
                    Author = author,
                    Pages = pages++,
                    Language = "Bulgarian",
                    ISBN = isbn++,
                    Category = category,
                };

                books.Add(currentBook);
            }

            foreach (var book in books)
            {
                await this.booksData.AddAsync(book);
            }

            await this.booksData.SaveChangesAsync();
        }
    }
}
