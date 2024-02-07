using Common.Entity.ValueObject;

namespace ClassDomain.Entities.Bill;

public class BillID:StronglyTypeId
{
    public BillID(Guid Value) : base(Value)
    {
    }
    
        
    public static implicit operator Guid(BillID StronglyId) => StronglyId.Value;
    public static implicit operator BillID(Guid value) => new BillID(value);

}