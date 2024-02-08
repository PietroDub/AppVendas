using AppVendasWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AppVendasWeb.Data
{
    public class AppVendasContext : DbContext
    {
        public AppVendasContext(DbContextOptions<AppVendasContext> options)
        : base(options)
        { }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
        }
    }
}
