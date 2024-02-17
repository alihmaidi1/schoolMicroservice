using Common.Entity.ValueObject;

namespace SubjectDomain.Entities.Semester;

public class SemesterID:StronglyTypeId
{
    public SemesterID(Guid Value) : base(Value)
    {
    }
}