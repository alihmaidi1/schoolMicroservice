using Common.Entity.ValueObject;

namespace ClassDomain.Entities.StudentClass;

public class StudentClassID:StronglyTypeId
{
    public StudentClassID(Guid Value) : base(Value)
    {
    }
    public static implicit operator Guid(StudentClassID StronglyId) => StronglyId.Value;
    public static implicit operator StudentClassID(Guid value) => new StudentClassID(value);

}