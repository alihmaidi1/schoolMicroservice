using Domain.Entities.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Teacherinfrutructure.Configration;

public class TeacherConfigration:IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {

        
        builder.HasQueryFilter(x => x.DateDeleted == null);
        builder.HasKey(Teacher => Teacher.Id);
        builder.Property(Teacher => Teacher.Id)
            .HasConversion(TeacherID => TeacherID.Value, Value => new TeacherID(Value));


        builder.HasMany(x => x.Vacations)
            .WithOne(x => x.Teacher)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        builder.HasMany(x => x.Warnings)
            .WithOne(x => x.Teacher)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
    }
}