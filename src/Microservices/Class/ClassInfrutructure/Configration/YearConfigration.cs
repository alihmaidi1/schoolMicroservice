using ClassDomain.Entities.Year;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassInfrutructure.Configration;

public class YearConfigration:IEntityTypeConfiguration<Year>
{
    public void Configure(EntityTypeBuilder<Year> builder)
    {

        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => x.DateDeleted == null);
        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new YearID(Value));


        builder.HasMany(x => x.ClassYears)
            .WithOne(x => x.Year)
            .HasForeignKey(x => x.YearId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}