namespace API_PROJECT.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IAds ads { get; }
        ICategories categories { get; }
        ICountries countries { get; }
        IProducts products { get; }
        IShop_Connects shop_Connects { get; }
        IShops shops { get; }
        ISub_Categories sub_Categories { get; }
        IUsers users { get; }
        int save();
    }

}
