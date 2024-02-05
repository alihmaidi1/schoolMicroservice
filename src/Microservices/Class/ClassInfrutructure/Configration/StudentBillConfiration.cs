using ClassDomain.Entities.Bill;
using ClassDomain.Entities.StudentBill;
using ClassDomain.Entities.StudentClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassInfrutructure.Configration;

public class StudentBillConfiration:IEntityTypeConfiguration<StudentBill>
{
    public void Configure(EntityTypeBuilder<StudentBill> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new StudentBillID(Value));
        
        builder.Property(x => x.BillId)
            .HasConversion(x => x.Value, Value => new BillID(Value));

        builder.Property(x => x.StudentClassId)
            .HasConversion(x => x.Value, Value => new StudentClassID(Value));


        builder.HasOne(x => x.StudentClass)
            .WithMany(x => x.StudentBills)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Bill)
            .WithMany(x => x.StudentBills)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}