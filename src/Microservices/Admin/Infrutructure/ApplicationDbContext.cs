using System.Reflection;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Manager.Role;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;

namespace Infrutructure;

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
    
    
    
    
    
    public DbSet<Admin> Admins { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<AdminRefreshToken> AdminRefreshTokens { get; set; }

    
    
    
    
}
