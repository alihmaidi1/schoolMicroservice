using Domain.Entities.Manager.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrutructure.Configration.Manager;

public class RefreshTokenAdminConfigration:IEntityTypeConfiguration<AdminRefreshToken>
{
    public void Configure(EntityTypeBuilder<AdminRefreshToken> builder)
    {

        builder.Property(x => x.AdminId).HasConversion(AdminId => AdminId.Value, value => new AdminID(value));
    }
}