using Common.Entity.ValueObject;

namespace ClassDomain.Entities.StudentBill;

public class StudentBillID:StronglyTypeId
{
    public StudentBillID(Guid Value) : base(Value)
    {
    }
    
    public static implicit operator Guid(StudentBillID StronglyId) => StronglyId.Value;
    public static implicit operator StudentBillID(Guid value) => new StudentBillID(value);

}