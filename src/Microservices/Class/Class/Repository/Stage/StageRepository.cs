using Class.Repository.Base;
using ClassDomain.Dto.Stage;
using ClassDomain.Entities.Stage;
using ClassDomain.Model.Stage.Query;
using ClassInfrutructure;
using Common.Entity.EntityOperation;
using Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace Class.Repository.Stage;

public class StageRepository:GenericRepository<ClassDomain.Entities.Stage.Stage>,IStageRepository
{
    public StageRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public PageList<GetAllStageResponse> GetAllStage(string? OrderBy, int? pageNumber, int? pageSize)
    {
        
        
        var Result = DbContext.Stages
        .Sort<StageID,ClassDomain.Entities.Stage.Stage>(OrderBy, StageSorting.switchOrdering)
        .Select(StageQuery.ToGetAllStage)
        .ToPagedList(pageNumber,pageSize);


        return Result;

        
    }

    public bool IsExists(StageID Id)
    {


        return DbContext.Stages.Any(x => x.Id == Id);
    }


    public GetStageresponse GetStage(StageID id)
    {

        return DbContext
            .Stages
            .Include(x=>x.Classes)
            .Select(StageQuery.ToGetStage)
            .Single(x => x.Id == id);
    }

}