using Common.Entity.ValueObject;

namespace SubjectDomain.Entities.Lesson;

public class LessonID:StronglyTypeId
{
    public LessonID(Guid Value) : base(Value)
    {
    }
}