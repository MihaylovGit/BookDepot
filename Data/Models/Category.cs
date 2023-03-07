namespace BookDepot.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int Id { get; set; }

    public Genre Genre { get; set; }

    public int BookId { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();
}
