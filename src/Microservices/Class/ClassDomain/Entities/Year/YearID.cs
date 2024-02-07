using Common.Entity.ValueObject;

namespace ClassDomain.Entities.Year;

public class YearID:StronglyTypeId
{
    public YearID(Guid Value) : base(Value)
    {
    }
    
    public static implicit operator Guid(YearID StronglyId) => StronglyId.Value;
    public static implicit operator YearID(Guid value) => new YearID(value);

}