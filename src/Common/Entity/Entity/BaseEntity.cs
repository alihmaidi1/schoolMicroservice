using Common.Entity.ValueObject;

namespace Common.Entity.Entity;

public class BaseEntity<TKey>:BaseEntityWithoutId  where TKey : StronglyTypeId
{
    
    
    public TKey Id { get; set; }

    
}