using Domain.Entities.Vacation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrutructure.Configration;

public class VacationConfigration:IEntityTypeConfiguration<Vacation>
{
    public void Configure(EntityTypeBuilder<Vacation> builder)
    {
        throw new NotImplementedException();
    }
}