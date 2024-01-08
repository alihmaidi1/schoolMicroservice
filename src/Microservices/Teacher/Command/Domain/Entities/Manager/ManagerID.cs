using Common.Entity.ValueObject;

namespace Domain.Entities.Manager;

public class ManagerID:StronglyTypeId
{
    public ManagerID(Guid Value) : base(Value)
    {
        
        
    }
    
    public static implicit operator Guid(ManagerID StronglyId) => StronglyId.Value;
    public static implicit operator ManagerID(Guid value) => new ManagerID(value);

    
}
