using Common.Entity.ValueObject;

namespace Common.Entity.Entity;

public class AccountEntity<TKey>:BaseEntityWithoutId where TKey : StronglyTypeId
{
    
    
    public TKey Id { get; set; }

    
}