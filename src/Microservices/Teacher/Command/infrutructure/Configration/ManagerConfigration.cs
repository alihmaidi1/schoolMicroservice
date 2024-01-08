using Domain.Entities.Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrutructure.Configration;

public class ManagerConfigration:IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(ManagerID => ManagerID.Value, Value => new ManagerID(Value));


        builder.HasMany(x => x.Vacations)
            .WithOne(x => x.Manager)
            .HasForeignKey(x=>x.ManagerId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        builder.HasMany(x => x.Warnings)
            .WithOne(x => x.Manager)
            .HasForeignKey(x=>x.ManagerId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}