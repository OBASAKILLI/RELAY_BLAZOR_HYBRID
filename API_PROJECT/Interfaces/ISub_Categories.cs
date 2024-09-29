using API_PROJECT.Context;
using API_PROJECT.Models;

namespace API_PROJECT.Interfaces
{
    public interface ISub_Categories:IGenericInterface<Sub_Categories>
    {
    }
    public class Sub_CategoriesRepository : GenericRepo<Sub_Categories>, ISub_Categories
    {
        public Sub_CategoriesRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
