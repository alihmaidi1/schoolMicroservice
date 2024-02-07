using ClassDomain.Entities.Parent;
using ClassDomain.Entities.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassInfrutructure.Configration;

public class StudentConfigration:IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new StudentID(Value));
        builder.Property(x => x.ParentId)
            .HasConversion(x => x.Value, Value => new ParentID(Value));

        builder.HasMany(x => x.StudentClasses)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}