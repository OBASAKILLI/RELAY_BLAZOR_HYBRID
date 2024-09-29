using API_PROJECT.Context;
using API_PROJECT.Models;

namespace API_PROJECT.Interfaces
{
    public interface IAds:IGenericInterface<Ads>
    {
    }
    public class AdsRepository : GenericRepo<Ads>, IAds
    {
        public AdsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
