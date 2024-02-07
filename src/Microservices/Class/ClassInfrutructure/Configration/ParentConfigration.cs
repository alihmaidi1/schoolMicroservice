using ClassDomain.Entities.Parent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassInfrutructure.Configration;

public class ParentConfigration:IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(x => x.DateDeleted==null);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new ParentID(Value));

        builder.HasMany(x => x.Students)
            .WithOne(x => x.Parent)
            .HasForeignKey(x => x.ParentId);


    }
}