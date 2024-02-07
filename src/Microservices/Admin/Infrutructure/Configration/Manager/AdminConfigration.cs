using Domain.Entities.Manager.Admin;
using Domain.Entities.Manager.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrutructure.Configration.Manager;

public class AdminConfigration:IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {

        builder.HasQueryFilter(x => x.DateDeleted == null);
        builder.HasKey(Admin => Admin.Id);
        builder.Property(Admin => Admin.Id)
            .HasConversion(AdminID => AdminID.Value, Value => new AdminID(Value));


        builder.Property(Admin => Admin.RoleId)
            .HasConversion(RoleID => RoleID.Value, Value => new RoleID(Value));

        builder.HasOne<Role>(Admin => Admin.Role)
            .WithMany(Role => Role.Admins)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.RefreshTokens)
            .WithOne(x => x.Admin)
            .HasForeignKey(x=>x.AdminId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}