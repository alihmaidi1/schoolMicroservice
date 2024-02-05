using ClassDomain.Entities.Semester;
using ClassDomain.Entities.Subject;
using ClassDomain.Entities.SubjectSemester;
using ClassDomain.Entities.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassInfrutructure.Configration;

public class SubjectSemesterConfigration:IEntityTypeConfiguration<SubjectSemester>
{
    public void Configure(EntityTypeBuilder<SubjectSemester> builder)
    {
     
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x=>x.Value,Value=>new SubjectSemesterID(Value));

        builder.Property(x => x.SemesterId)
            .HasConversion(x => x.Value, Value => new SemesterID(Value));
        builder.Property(x => x.SubjectId)
            .HasConversion(x => x.Value, Value => new SubjectID(Value));
        builder.Property(x => x.TeacherId)
            .HasConversion(x => x.Value, Value => new TeacherID(Value));

    }
}