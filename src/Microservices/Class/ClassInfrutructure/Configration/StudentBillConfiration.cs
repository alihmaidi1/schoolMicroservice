using ClassDomain.Entities.Bill;
using ClassDomain.Entities.StudentBill;
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
        
    }
}