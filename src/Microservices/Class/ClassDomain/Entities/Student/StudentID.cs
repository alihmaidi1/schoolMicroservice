using Common.Entity.ValueObject;

namespace ClassDomain.Entities.Student;

public class StudentID:StronglyTypeId
{
    public StudentID(Guid Value) : base(Value)
    {
    }
    
    
    public static implicit operator Guid(StudentID StronglyId) => StronglyId.Value;
    public static implicit operator StudentID(Guid value) => new StudentID(value);

}