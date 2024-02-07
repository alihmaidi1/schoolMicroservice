namespace Common.Entity.ValueObject;

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