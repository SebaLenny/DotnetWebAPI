using System.Threading.Tasks;

namespace DotnetWebAPI.Services
{
    public interface IUniversalService
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}