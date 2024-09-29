using API_PROJECT.Context;
using API_PROJECT.Models;

namespace API_PROJECT.Interfaces
{
    public interface IShop_Connects:IGenericInterface<Shop_Connects>
    {

    }
    public class Shop_ConnectsRepository : GenericRepo<Shop_Connects>, IShop_Connects
    {
        public Shop_ConnectsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
