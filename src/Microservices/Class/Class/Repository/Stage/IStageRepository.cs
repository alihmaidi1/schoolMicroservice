using Class.Repository.Base;
using ClassDomain.Dto.Stage;
using ClassDomain.Entities.Stage;
using Common.Entity.EntityOperation;

namespace Class.Repository.Stage;

public interface IStageRepository:IgenericRepository<ClassDomain.Entities.Stage.Stage>
{
    
    public PageList<GetAllStageResponse> GetAllStage(string? OrderBy, int? pageNumber, int? pageSize);


    public GetStageresponse GetStage(StageID id);
    public bool IsExists(StageID Id);
}