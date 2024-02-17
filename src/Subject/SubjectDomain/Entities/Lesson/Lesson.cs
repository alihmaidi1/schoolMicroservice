using Common.Entity.Entity;

namespace SubjectDomain.Entities.Lesson;

public class Lesson:BaseEntity<LessonID>
{

    public Lesson()
    {
        Id = new LessonID(Guid.NewGuid());
    }
    
    public string Name { get; set; }
    public string Url { get; set; }
    
    
}