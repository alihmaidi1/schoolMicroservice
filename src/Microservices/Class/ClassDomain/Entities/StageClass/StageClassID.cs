using Common.Entity.ValueObject;

namespace ClassDomain.Entities.StageClass;

public class StageClassID:StronglyTypeId
{
    public StageClassID(Guid Value) : base(Value)
    {
    }
    
    
    public static implicit operator Guid(StageClassID StronglyId) => StronglyId.Value;
    public static implicit operator StageClassID(Guid value) => new StageClassID(value);

}