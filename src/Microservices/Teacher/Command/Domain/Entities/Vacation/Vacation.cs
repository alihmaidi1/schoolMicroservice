using Common.Entity.Entity;
using Domain.Entities.Manager;
using Domain.Entities.Teacher;
using Domain.Entities.YearVacation;

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

    
    public ManagerID ManagerId { get; set; }
    public Manager.Manager Manager { get; set; }
    
    public Teacher.Teacher Teacher { get; set; }
    public TeacherID TeacherId { get; set; }
    
    
    
    public Year Year { get; set; }
    public YearVacationID YearId { get; set; }
    
    
}