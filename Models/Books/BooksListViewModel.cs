namespace BookDepot.Models.Books;

public class BooksListViewModel
{
    public BooksListViewModel()
    {
        this.AllBooks = new HashSet<BooksInListViewModel>();
    }

    public IEnumerable<BooksInListViewModel> AllBooks { get; set; }
}
