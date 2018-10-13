using Microsoft.EntityFrameworkCore;
using Safebet.WebAPI.Models;

namespace Safebet.WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<TimePoint> TimePoints { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base (options)
        {
        }
    }
}