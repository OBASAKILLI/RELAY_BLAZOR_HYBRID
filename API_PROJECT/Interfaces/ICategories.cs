using API_PROJECT.Context;
using API_PROJECT.Models;

namespace API_PROJECT.Interfaces
{
    public interface ICategories:IGenericInterface<Categories>
    {
    }
    public class CategoriesRepository : GenericRepo<Categories>, ICategories
    {
        public CategoriesRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
