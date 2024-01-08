using Common.Entity.ValueObject;

namespace Domain.Entities.Teacher;

public class TeacherID:StronglyTypeId
{
    
    
    public TeacherID(Guid Value) : base(Value)
    {
    }
    
    
    public static implicit operator Guid(TeacherID StronglyId) => StronglyId.Value;
    public static implicit operator TeacherID(Guid value) => new TeacherID(value);

    
}