using Common.Entity.ValueObject;

namespace SubjectDomain.Entities.Subject;

public class SubjectID:StronglyTypeId
{
    public SubjectID(Guid Value) : base(Value)
    {
    }
}