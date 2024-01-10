using Domain.Entities.Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Teacherinfrutructure.Configration;

public class ManagerConfigration:IEntityTypeConfiguration<Domain.Entities.Manager.Manager>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Manager.Manager> builder)
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