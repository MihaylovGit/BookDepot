namespace BookDepot.Data.Models;

using System.ComponentModel.DataAnnotations;
using static BookDepot.Data.Validations.DataValidation.Author;

public class Author
{
    [Key]
    public int Id { get; set; }

    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;
}
