using Microsoft.EntityFrameworkCore;
using PrayWay.Domain.Entities;

namespace PrayWay.Infrastructure.Persistence.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Place> Places { get; set; }
    }
}