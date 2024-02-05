using Common.Entity.ValueObject;

namespace ClassDomain.Entities.StageClass;

public class ClassYearID:StronglyTypeId
{
    public ClassYearID(Guid Value) : base(Value)
    {
    }
    
    
    public static implicit operator Guid(ClassYearID stronglyYearId) => stronglyYearId.Value;
    public static implicit operator ClassYearID(Guid value) => new ClassYearID(value);

}