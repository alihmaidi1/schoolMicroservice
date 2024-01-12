using Common.Entity.ValueObject;

namespace ClassDomain.Entities.Semester;

public class SemesterID:StronglyTypeId
{
    public SemesterID(Guid Value) : base(Value)
    {
    }
    
    
    public static implicit operator Guid(SemesterID StronglyId) => StronglyId.Value;
    public static implicit operator SemesterID(Guid value) => new SemesterID(value);

    
}