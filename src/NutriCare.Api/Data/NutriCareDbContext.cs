using Microsoft.EntityFrameworkCore;

namespace NutriCare.Api.Data
{
  public class NutriCareDbContext : DbContext
  {
      public NutriCareDbContext(DbContextOptions<NutriCareDbContext> options) : base(options) { }

        protected NutriCareDbContext()
        {

        }

        //public DbSet<MyEntity> MyEntities { get; set; }
    }
}