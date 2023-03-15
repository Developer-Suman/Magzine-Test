using Megazine.Models;
using Microsoft.EntityFrameworkCore;

namespace Megazine.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 

        }
        public DbSet<ArticleSecond> Articles { get; set; } 
        public DbSet<Journal> Journals { get; set; }
        public DbSet<News> Newss { get; set; } 
        public DbSet<Advertisement> Advertisements { get; set; }
    }
}
