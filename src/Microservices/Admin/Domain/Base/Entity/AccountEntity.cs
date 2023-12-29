using Domain.Base.ValueObject;

namespace Domain.Base.Entity;

public class AccountEntity<TKey>:BaseEntityWithoutId where TKey : StronglyTypeId
{
    
    
    public TKey Id { get; set; }

    
}