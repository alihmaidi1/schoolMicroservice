using ClassDomain.Entities.Class;
using ClassDomain.Entities.ClassYear;
using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.StudentClass;
using ClassDomain.Entities.Year;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassInfrutructure.Configration;

public class ClassYearConfigration:IEntityTypeConfiguration<ClassYear>
{
    public void Configure(EntityTypeBuilder<ClassYear> builder)
    {

        builder.HasKey(x => x.Id);

        builder.HasIndex(p => new { p.YearId, p.ClassId }).IsUnique();
        
        
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new ClassYearID(Value));
        builder.Property(x => x.ClassId)
            .HasConversion(Id => Id.Value, Value => new ClassID(Value));

        builder.Property(x => x.YearId)
            .HasConversion(x => x.Value, Value => new YearID(Value));
        
        builder.HasMany(x => x.Bills)
            .WithOne(x => x.ClassYear)
            .HasForeignKey(x=>x.ClassYearId);

        
        builder.HasMany(x => x.Students)
            .WithMany(x => x.ClassYears)
            .UsingEntity<StudentClass>();

        builder.HasMany(x => x.StudentClasses)
            .WithOne(x=>x.ClassYear)
            .HasForeignKey(x=>x.ClassYearId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Semesters)
            .WithOne(x => x.ClassYear)
            .HasForeignKey(x=>x.ClassYearId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}