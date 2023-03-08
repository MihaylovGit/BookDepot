namespace BookDepot.Services
{
    using System.Threading.Tasks;

    public interface IBooksScraperService
    {
       Task PopulateDbWithBooks();
    }
}
