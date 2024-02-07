using Common.Entity.ValueObject;

namespace Domain.Entities.YearVacation;

public class YearVacationID:StronglyTypeId
{
    public YearVacationID(Guid Value) : base(Value)
    {
    }
    
    
    
    
    public static implicit operator Guid(YearVacationID StronglyId) => StronglyId.Value;
    public static implicit operator YearVacationID(Guid value) => new YearVacationID(value);

}