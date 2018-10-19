using LimeHouseSky.Db.Local.Models;
using Microsoft.EntityFrameworkCore;

namespace LimeHouseSky.Db.Local.Context
{
    public class MobileContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public MobileContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Mobile.db");
        }
    }
}
