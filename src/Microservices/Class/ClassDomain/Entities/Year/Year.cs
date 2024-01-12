using Common.Entity.Entity;

namespace ClassDomain.Entities.Year;

public class Year:BaseEntity<YearID>
{

    public Year()
    {

        Id = new YearID(Guid.NewGuid());

    }
    
    
    public string Name { get; set; }
    
    
    
}