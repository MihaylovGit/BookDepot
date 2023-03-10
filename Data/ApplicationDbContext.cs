namespace BookDepot.Data;

using BookDepot.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>()
               .HasOne(c => c.Author);

        builder.Entity<Book>();

        builder.Entity<Author>()
               .HasMany(b => b.Books);

        builder.Entity<Book>()
               .Property(b => b.Price)
               .HasPrecision(15, 2);

        base.OnModelCreating(builder);
    }
}



