using ClassDomain.Entities.Semester;
using ClassDomain.Entities.Subject;
using ClassDomain.Entities.Teacher;
using Common.Entity.Entity;

namespace ClassDomain.Entities.SubjectSemester;

public class SubjectSemester:BaseEntity<SubjectSemesterID>
{

    public SubjectSemester()
    {
        
        Id = new SubjectSemesterID(Guid.NewGuid());

    }
    
    public TeacherID TeacherId { get; set; }
    
    
    public SemesterID SemesterId { get; set; }
    
    
    public SubjectID SubjectId { get; set; }
}