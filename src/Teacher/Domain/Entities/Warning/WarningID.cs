using Common.Entity.ValueObject;

namespace Domain.Entities.Warning;

public class WarningID:StronglyTypeId
{
    public WarningID(Guid Value) : base(Value)
    {
    }
        
    public static implicit operator Guid(WarningID StronglyId) => StronglyId.Value;
    public static implicit operator WarningID(Guid value) => new WarningID(value);

}