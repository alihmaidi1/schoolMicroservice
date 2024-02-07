using Common.Entity.Entity;

namespace Domain.Entities.YearVacation;

public class Year:BaseEntity<YearVacationID>
{
    
    
    public Year()
    {

        Id = new YearVacationID(Guid.NewGuid());
        Vacations = new HashSet<Vacation.Vacation>();
    }
    
    
    
    public ICollection<Vacation.Vacation> Vacations { get; set; }
    
    
    
    public string Name { get; set; }
    
    
    
    
}
