using Common.Entity.ValueObject;

namespace ClassDomain.Entities.Class;

public class ClassID:StronglyTypeId
{
    public ClassID(Guid Value) : base(Value)
    {
    }
    
    
    public static implicit operator Guid(ClassID StronglyId) => StronglyId.Value;
    public static implicit operator ClassID(Guid value) => new ClassID(value);

}