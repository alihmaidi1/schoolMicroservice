using Domain.Entities.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrutructure.Configration;

public class TeacherConfigration:IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        throw new NotImplementedException();
    }
}