using Common.Entity.ValueObject;

namespace Domain.Entities.Manager.Role;

public class RoleID:StronglyTypeId
{
    
    
    public RoleID(Guid Value) : base(Value)
    {
    }
    
    public static implicit operator Guid(RoleID StronglyId) => StronglyId.Value;
    public static implicit operator RoleID(Guid value) => new RoleID(value);


}