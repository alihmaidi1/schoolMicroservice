using ClassInfrutructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Class.Repository.Base;

public class GenericRepository<T>: IgenericRepository<T> where T : class
{
    public readonly ApplicationDbContext DbContext;
    public GenericRepository(ApplicationDbContext DbContext) {

        this.DbContext = DbContext;
    }
    public virtual async Task<T> AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public IDbContextTransaction BeginTransaction()
    {

        return DbContext.Database.BeginTransaction();
    }

    public void Commit()
    {

        DbContext.Database.CommitTransaction();
    }

    public  Task DeleteAsync(T entity)
    {

        DbContext.Set<T>().Remove(entity);
        DbContext.SaveChanges();
        return Task.CompletedTask;
    }


    public virtual async Task<List<T>> GetAllasync()
    {

        return await DbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {

        return await DbContext.Set<T>().FindAsync(id);

    }

    public IQueryable<T> GetTableAsNoTracking()
    {           
        return DbContext.Set<T>().AsNoTracking().AsQueryable();
    }

    public IQueryable<T> GetTableAsTracking()
    {
        return DbContext.Set<T>().AsTracking().AsQueryable();
    }

    public void Rollback()
    {
        DbContext.Database.RollbackTransaction();
    }

    public virtual async  Task  UpdateAsync(T entity)
    {

        DbContext.Set<T>().Update(entity);
        await DbContext.SaveChangesAsync();


    }

}