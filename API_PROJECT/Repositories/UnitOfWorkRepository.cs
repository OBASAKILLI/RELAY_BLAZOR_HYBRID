using API_PROJECT.Context;
using API_PROJECT.Interfaces;
using API_PROJECT.Models;

namespace API_PROJECT.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWorkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            ads = new AdsRepository(_appDbContext);
            categories = new CategoriesRepository(_appDbContext);
            countries = new CountriesRepository(_appDbContext);
            products = new ProductsRepository(_appDbContext);
            shop_Connects= new Shop_ConnectsRepository(_appDbContext);
            shops = new ShopsRepository(_appDbContext);
            users= new UsersRepository(_appDbContext);
            sub_Categories = new   Sub_CategoriesRepository(_appDbContext);
        }
        public IAds ads { get; private set; }

        public ICategories categories { get; private set; }

        public ICountries countries { get; private set; }

        public IProducts products { get; private set; }

        public IShop_Connects shop_Connects { get; private set; }

        public IShops shops { get; private set; }

        public ISub_Categories sub_Categories { get; private set; }

        public IUsers users { get; private set; }

        public int save()
        {
            return _appDbContext.SaveChanges();
        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
