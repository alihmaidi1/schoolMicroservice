using Domain.Repository.Base;

namespace Domain.Repository.Warning;

public interface IWarningRepository:IgenericRepository<Entities.Warning.Warning>
{


    public bool IsExists(Guid Id);
}