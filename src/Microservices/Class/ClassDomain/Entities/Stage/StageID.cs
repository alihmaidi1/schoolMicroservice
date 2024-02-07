using Common.Entity.ValueObject;

namespace ClassDomain.Entities.Stage;

public class StageID:StronglyTypeId
{
    public StageID(Guid Value) : base(Value)
    {
    }
    
    
    
    public static implicit operator Guid(StageID StronglyId) => StronglyId.Value;
    public static implicit operator StageID(Guid value) => new StageID(value);

}