using Common.Entity.Entity;
using Domain.Entities.Teacher;

namespace Domain.Entities.Vacation;

public class Vacation:BaseEntity<VacationID>
{

    public Vacation()
    {

        Id = new VacationID(Guid.NewGuid());
    }
    
    public string Reason { get; set; }
    public bool Status { get; set; }
    public int Days { get; set; }
    public TeacherID TeacherId { get; set; }
    public Guid YearId { get; set; }
    
    
    
}