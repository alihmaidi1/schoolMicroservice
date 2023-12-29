using Domain.Entities.Manager.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrutructure.Configration.Manager;

public class RoleConfigration:IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        
        builder.HasKey(Role => Role.Id);
        builder.Property(Role => Role.Id)
            .HasConversion(RoleID => RoleID.Value, Value => new RoleID(Value));

        builder.Property(x => x.Permissions)
            .HasConversion(Permissions => JsonConvert.SerializeObject(Permissions),
                Permissions => JsonConvert.DeserializeObject<List<string>>(Permissions));

    }
}