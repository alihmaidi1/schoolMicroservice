using System.Reflection;
using Domain.Entities;
using Domain.Entities.Manager;
using Domain.Entities.Teacher;
using Domain.Entities.Vacation;
using Domain.Entities.Warning;
using Domain.Entities.YearVacation;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;

namespace Teacherinfrutructure;

public class ApplicationDbContext:DbContext
{
    
    public IEncryptionProvider EncryptionProvider { get; set; }

    
    public ApplicationDbContext(DbContextOptions option) :base(option)
    {

        EncryptionProvider = new GenerateEncryptionProvider("45sdfow342joir53");
            

    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    
        builder.UseEncryption(EncryptionProvider);
        base.OnModelCreating(builder);
    
    }

    public DbSet<Warning> Warnings { get; set; }
    
    public DbSet<Manager> Managers { get; set; }

    public DbSet<Year> Year { get; set; }
    
    
    
    public DbSet<Vacation> Vacations { get; set; }
    
    public DbSet<Teacher> Teachers { get; set; }

    
}