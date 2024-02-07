using Microsoft.EntityFrameworkCore.Storage;

namespace Repository.Base;

public interface IgenericRepository<T> where T : class
{
    
    
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> GetAllasync();

    Task<T> GetByIdAsync(Guid id);
    void Commit();
    void Rollback();
    IDbContextTransaction BeginTransaction();


    IQueryable<T> GetTableAsNoTracking();
    IQueryable<T> GetTableAsTracking();






    
}