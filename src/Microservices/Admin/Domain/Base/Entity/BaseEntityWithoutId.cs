using Domain.Base.Interface;

namespace Domain.Base.Entity;

public class BaseEntityWithoutId:IBaseEntity
{
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateDeleted { get; set; }
    public DateTime? DateUpdated { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public Guid? DeletedBy { get; set; }

    
}