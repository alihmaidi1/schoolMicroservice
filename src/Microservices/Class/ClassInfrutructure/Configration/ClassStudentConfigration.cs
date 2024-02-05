using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.Student;
using ClassDomain.Entities.StudentClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassInfrutructure.Configration;

public class ClassStudentConfigration:IEntityTypeConfiguration<StudentClass>
{
    
    public void Configure(EntityTypeBuilder<StudentClass> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x=>x.Value,Value=>new StudentClassID(Value));
        builder.Property(x => x.ClassYearId)
            .HasConversion(x => x.Value, Value => new ClassYearID(Value));

        builder.Property(x => x.StudentId)
            .HasConversion(x => x.Value, Value => new StudentID(Value));
        
        
    }
}