using API_PROJECT.Context;
using API_PROJECT.Models;

namespace API_PROJECT.Interfaces
{
    public interface ICountries:IGenericInterface<Countries>
    {
    }
    public class CountriesRepository : GenericRepo<Countries>, ICountries
    {
        public CountriesRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
