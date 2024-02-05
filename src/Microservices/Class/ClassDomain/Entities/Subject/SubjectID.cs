using Common.Entity.ValueObject;

namespace ClassDomain.Entities.Subject;

public class SubjectID:StronglyTypeId
{
    public SubjectID(Guid Value) : base(Value)
    {
    }
    
    public static implicit operator Guid(SubjectID StronglyId) => StronglyId.Value;
    public static implicit operator SubjectID(Guid value) => new SubjectID(value);

}