namespace Domain.Base.ValueObject;

public abstract class ValueObject
{
    
    protected static bool EqualOperator(ValueObject? left, ValueObject? right)
    {
        if (ReferenceEquals(left, objB: null) ^ ReferenceEquals(right, objB: null)) return false;

        return ReferenceEquals(left, objB: null) || left.Equals(right);
    }





    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !(EqualOperator(left, right));
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()) return false;

        var other = (ValueObject)obj;

        return this.GetValues().SequenceEqual(other.GetValues());
    }

    public abstract IEnumerable<object> GetValues();


    
}