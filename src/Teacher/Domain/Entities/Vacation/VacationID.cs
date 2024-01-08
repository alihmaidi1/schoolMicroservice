using Common.Entity.ValueObject;

namespace Domain.Entities.Vacation;

public class VacationID:StronglyTypeId
{
    public VacationID(Guid Value) : base(Value)
    {
    }
    
    public static implicit operator Guid(VacationID StronglyId) => StronglyId.Value;
    public static implicit operator VacationID(Guid value) => new VacationID(value);

}