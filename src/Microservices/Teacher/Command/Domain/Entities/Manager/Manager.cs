using Common.Entity.Entity;
using Common.Entity.ValueObject;

namespace Domain.Entities.Manager;

public class Manager:BaseEntity<ManagerID>
{

    public Manager()
    {

        Id = new ManagerID(Guid.NewGuid());
        Warnings = new HashSet<Warning.Warning>();
        Vacations = new HashSet<Vacation.Vacation>();

    }


    
    public string Name { get; set; }

    public Guid ManagerId { get; set; }
    public ICollection<Warning.Warning> Warnings { get; set; }
    
    
    public ICollection<Vacation.Vacation> Vacations { get; set; }
    
    
}