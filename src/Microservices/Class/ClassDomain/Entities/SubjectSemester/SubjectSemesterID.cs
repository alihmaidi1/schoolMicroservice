using Common.Entity.ValueObject;

namespace ClassDomain.Entities.SubjectSemester;

public class SubjectSemesterID:StronglyTypeId
{
    public SubjectSemesterID(Guid Value) : base(Value)
    {
    }
    
    
    public static implicit operator Guid(SubjectSemesterID StronglyId) => StronglyId.Value;
    public static implicit operator SubjectSemesterID(Guid value) => new SubjectSemesterID(value);

}
