namespace BookDepot.Data.Models;

using System.ComponentModel.DataAnnotations;
using static BookDepot.Data.Validations.DataValidation.Book;

public class Book
{
    [Key]
    public int Id { get; set; }

    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; } = null!;

    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    public DateTime PublishedOn { get; set; }

    public int Pages { get; set; }

    public string Language { get; set; } = null!;

    public long ISBN { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

   public Category Category { get; set; } = null!;
}




