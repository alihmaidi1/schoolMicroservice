using Common.Entity.ValueObject;

namespace SubjectDomain.Entities.SemesterSubject;

public class SemesterSubjectID:StronglyTypeId
{
    public SemesterSubjectID(Guid Value) : base(Value)
    {
    }
}