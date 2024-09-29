using API_PROJECT.Context;
using API_PROJECT.Models;

namespace API_PROJECT.Interfaces
{
    public interface IShops:IGenericInterface<Shops>
    {
    }
    public class ShopsRepository : GenericRepo<Shops>, IShops
    {
        public ShopsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
