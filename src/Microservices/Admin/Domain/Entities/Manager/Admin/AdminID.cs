using Domain.Base.ValueObject;

namespace Domain.Entities.Manager.Admin;

public class AdminID:StronglyTypeId
{
    public AdminID(Guid Value) : base(Value)
    {
    }
    
    public static implicit operator Guid(AdminID StronglyId) => StronglyId.Value;
    public static implicit operator AdminID(Guid value) => new AdminID(value);

    
}