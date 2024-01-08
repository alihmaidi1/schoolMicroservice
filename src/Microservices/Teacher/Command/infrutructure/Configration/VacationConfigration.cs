using Domain.Entities.Manager;
using Domain.Entities.Teacher;
using Domain.Entities.Vacation;
using Domain.Entities.YearVacation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrutructure.Configration;

public class VacationConfigration:IEntityTypeConfiguration<Vacation>
{
    public void Configure(EntityTypeBuilder<Vacation> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(VacationID => VacationID.Value, Value => new VacationID(Value));


        builder.Property(x => x.TeacherId)
            .HasConversion(TeacherId => TeacherId.Value, Value => new TeacherID(Value));

        builder.Property(x => x.ManagerId)
            .HasConversion(x => x.Value, Value => new ManagerID(Value));

        builder.Property(x => x.YearId)
            .HasConversion(x => x.Value, Value => new YearVacationID(Value));
        




    }
}