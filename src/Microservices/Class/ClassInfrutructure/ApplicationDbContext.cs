using System.Reflection;
using ClassDomain.Entities.Bill;
using ClassDomain.Entities.Class;
using ClassDomain.Entities.ClassYear;
using ClassDomain.Entities.Parent;
using ClassDomain.Entities.Semester;
using ClassDomain.Entities.Stage;
using ClassDomain.Entities.Student;
using ClassDomain.Entities.StudentBill;
using ClassDomain.Entities.StudentClass;
using ClassDomain.Entities.Year;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;

namespace ClassInfrutructure;

public class ApplicationDbContext:DbContext
{
 
    public IEncryptionProvider EncryptionProvider { get; set; }

    
    public ApplicationDbContext(DbContextOptions option) :base(option)
    {

        EncryptionProvider = new GenerateEncryptionProvider("45sdfodsfw3sdfsd42joir53");
            

    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    
        builder.UseEncryption(EncryptionProvider);
        base.OnModelCreating(builder);
    
    }


    public DbSet<Stage> Stages { get; set; }

    public DbSet<Class> Classes { get; set; }

    
    
    public DbSet< Bill> Bills { get; set; }
    public DbSet<ClassYear> ClassYears { get; set; }
    public DbSet<Year> Years { get; set; }
    
    public DbSet<Semester> Semesters { get; set; }
    
    public DbSet<Parent> Parents { get; set; }
    
    
    public DbSet<Student> Students { get; set; }

    public DbSet<StudentClass> StudentClasses { get; set; }
    
    public DbSet<StudentBill> StudentBills { get; set; }
}