using Domain.Entities.Manager;
using Repository.Base;
using Teacherinfrutructure;

namespace Domain.Repository;

public class ManagerRepository:GenericRepository<Manager>,IManagerRepository
{
    
    
    public ManagerRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }
    
    
    
    
}