using API_PROJECT.Context;
using API_PROJECT.Models;

namespace API_PROJECT.Interfaces
{
    public interface IProducts:IGenericInterface<Products>
    {
    }
    public class ProductsRepository : GenericRepo<Products>,
        IProducts
    {
        public ProductsRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
