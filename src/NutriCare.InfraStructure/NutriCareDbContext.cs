using Microsoft.EntityFrameworkCore;
using NutriCare.Core.Entities;

namespace NutriCare.InfraStructure
{
  public class NutriCareDbContext : DbContext
  {
    public NutriCareDbContext(DbContextOptions<NutriCareDbContext> options) : base(options) 
    { 

    }
    protected NutriCareDbContext()
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });
    }
    public DbSet<User> Users { get; set; }
  }
}