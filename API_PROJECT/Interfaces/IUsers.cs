using API_PROJECT.Context;
using API_PROJECT.Models;

namespace API_PROJECT.Interfaces
{
    public interface IUsers:IGenericInterface<Users>
    {
    }
    public class UsersRepository : GenericRepo<Users>, IUsers
    {
        public UsersRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
