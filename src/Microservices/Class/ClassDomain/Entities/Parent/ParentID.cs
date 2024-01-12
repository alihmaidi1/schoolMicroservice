using Common.Entity.ValueObject;

namespace ClassDomain.Entities.Parent;

public class ParentID:StronglyTypeId
{
    public ParentID(Guid Value) : base(Value)
    {
    }
    
    
    public static implicit operator Guid(ParentID StronglyId) => StronglyId.Value;
    public static implicit operator ParentID(Guid value) => new ParentID(value);

}