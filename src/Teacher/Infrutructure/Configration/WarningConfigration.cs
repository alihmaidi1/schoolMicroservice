using Domain.Entities.Warning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrutructure.Configration;

public class WarningConfigration:IEntityTypeConfiguration<Warning>
{
    public void Configure(EntityTypeBuilder<Warning> builder)
    {
        throw new NotImplementedException();
    }
}