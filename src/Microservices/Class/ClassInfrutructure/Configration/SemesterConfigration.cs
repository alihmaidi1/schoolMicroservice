using ClassDomain.Entities.Semester;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassInfrutructure.Configration;

public class SemesterConfigration:IEntityTypeConfiguration<Semester>
{
    public void Configure(EntityTypeBuilder<Semester> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(x => x.DateDeleted == null);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new SemesterID(Value));
        
        
        
        
    }
}