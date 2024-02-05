using System.Reflection;
using ClassDomain.Entities.Bill;
using ClassDomain.Entities.Class;
using ClassDomain.Entities.Stage;
using ClassDomain.Entities.StageClass;
using ClassDomain.Entities.Subject;
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

        EncryptionProvider = new GenerateEncryptionProvider("45sdfow3sdfsd42joir53");
            

    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    
        builder.UseEncryption(EncryptionProvider);
        base.OnModelCreating(builder);
    
    }


    public DbSet<Stage> Stages { get; set; }

    public DbSet<Class> Classes { get; set; }

    
    public DbSet<Subject> Subjects { get; set; }
    
    public DbSet< Bill> Bills { get; set; }
    public DbSet<ClassYear> ClassYears { get; set; }
    public DbSet<Year> Years { get; set; }
    
    
}