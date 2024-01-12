using Repository.Base;
using Teacherinfrutructure;

namespace Domain.Repository.Warning;

public class WarningRepository:GenericRepository<Entities.Warning.Warning>,IWarningRepository
{
    public WarningRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }


    public bool IsExists(Guid Id)
    {

        return DbContext.Warnings.Any(x => x.Id == Id);
    }

    
    
}