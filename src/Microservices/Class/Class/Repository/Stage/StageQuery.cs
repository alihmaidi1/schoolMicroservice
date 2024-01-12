using System.Linq.Expressions;
using ClassDomain.Dto.Class;
using ClassDomain.Dto.Stage;

namespace Class.Repository.Stage;

public static class StageQuery
{
    public static Expression<Func<ClassDomain.Entities.Stage.Stage, GetAllStageResponse>> ToGetAllStage = Stage =>
        new GetAllStageResponse()
        {
            Id = Stage.Id.Value,
            Name = Stage.Name,
        };

    
    public static Expression<Func<ClassDomain.Entities.Stage.Stage, GetStageresponse>> ToGetStage = Stage =>
        new GetStageresponse()
        {
            Id = Stage.Id,
            Name = Stage.Name,
            Classes = Stage.Classes.Select(x=>new GetClassResponse()
            {
                Id= x.Id,
                Name = x.Name
                
            }).ToList()
        };

    
}