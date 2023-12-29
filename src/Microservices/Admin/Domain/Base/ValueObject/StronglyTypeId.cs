namespace Domain.Base.ValueObject;

public class StronglyTypeId:ValueObject
{
    
    public Guid Value;

    public StronglyTypeId(Guid Value) {
        this.Value = Value;
    }

        
    public override IEnumerable<object> GetValues()
    {
        yield return Value;
    }

    
}