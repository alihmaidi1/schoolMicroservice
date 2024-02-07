using Domain.Entities.YearVacation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Teacherinfrutructure.Configration;

public class YearVacationConfigration:IEntityTypeConfiguration<Year>
{
    public void Configure(EntityTypeBuilder<Year> builder)
    {

        
        builder.Property(x => x.Id)
            .HasConversion(YearVacationID => YearVacationID.Value, Value => new YearVacationID(Value));

        builder.HasMany(x => x.Vacations)
            .WithOne(x => x.Year)
            .HasForeignKey(x => x.YearId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        
    }
    
}