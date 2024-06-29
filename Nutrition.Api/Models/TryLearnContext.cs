using Microsoft.EntityFrameworkCore;

namespace Nutrition.Api.Models
{
    public class TryLearnContext
    {
        public TryLearnContext(DbContextOptions<TryLearnContext> options) : base(options)
        {

        }

        public DbSet<TryLearn> TryLearns {get; set;} = null;
    }
}