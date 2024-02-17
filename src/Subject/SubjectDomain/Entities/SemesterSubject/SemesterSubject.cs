using Common.Entity.Entity;
using SubjectDomain.Entities.Semester;
using SubjectDomain.Entities.Subject;

namespace SubjectDomain.Entities.SemesterSubject;

public class SemesterSubject:BaseEntity<SemesterSubjectID>
{


    public SemesterSubject()
    {

        Id = new SemesterSubjectID(Guid.NewGuid());

    }
    
    public SubjectID SubjectId { get; set; }
    public SemesterID SemesterId { get; set; }
    
}