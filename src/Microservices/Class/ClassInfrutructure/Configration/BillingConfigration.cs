using ClassDomain.Entities.Bill;
using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.StudentBill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassInfrutructure.Configration;

public class BillingConfigration:IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {

        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(x => x.DateDeleted == null);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new BillID(Value));

        builder.Property(x => x.ClassYearId)
            .HasConversion(x => x.Value, Value => new ClassYearID(Value));

        builder.HasMany(x => x.StudentBills)
            .WithOne(x => x.Bill)
            .HasForeignKey(x => x.BillId);

        builder.HasMany(x => x.StudentClasses)
            .WithMany(x => x.Bills)
            .UsingEntity<StudentBill>();

    }
}