using API_PROJECT.Context;
using API_PROJECT.Models;
using Microsoft.EntityFrameworkCore;

namespace API_PROJECT.Interfaces
{
    public interface IGenericInterface<T> where T : class
    {
        Task AddNew(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(string Id);
        Task Remove(T entity);
        Task Update(T entity);
    }



    public class GenericRepo<T> : IGenericInterface<T> where T : class
    {
        public readonly AppDbContext _appDbContext;


        public GenericRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddNew(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);

        }

        public async Task<List<T>> GetAll()
        {

            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(string Id)
        {


            return await _appDbContext.Set<T>().FindAsync(Id);

        }

        public async Task Remove(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public async Task Update(T entity)
        {
            _appDbContext.Set<T>().Update(entity);


        }
    }
}
