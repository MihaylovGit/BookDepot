namespace BookDepot.Data.Models;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public Author Author { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime PublishedOn { get; set; }

    public int Pages { get; set; }

    public string Language { get; set; } = null!;

    public string ISBN { get; set; } = null!;
}
