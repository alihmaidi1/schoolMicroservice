using Domain.Entities.Manager;
using Domain.Entities.Teacher;
using Domain.Entities.Warning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Teacherinfrutructure.Configration;

public class WarningConfigration:IEntityTypeConfiguration<Warning>
{
    public void Configure(EntityTypeBuilder<Warning> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(ManagerId => ManagerId.Value,Value=>new WarningID(Value));


        builder.Property(x => x.ManagerId)
            .HasConversion(ManagerId => ManagerId.Value, Value => new ManagerID(Value));

        builder.Property(x => x.TeacherId)
            .HasConversion(TeacherId => TeacherId.Value, Value => new TeacherID(Value));
        

    }
}