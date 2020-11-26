using System.Threading.Tasks;
using DotnetWebAPI.Models;

namespace DotnetWebAPI.Services
{
    public class UniversalService : IUniversalService
    {
        private readonly AppDbContext appDbContext;

        public UniversalService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Update<T>(T entity) where T : class
        {
            appDbContext.Update(entity);
        }
        public void Add<T>(T entity) where T : class
        {
            appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            appDbContext.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await appDbContext.SaveChangesAsync() > 0;
        }
    }
}