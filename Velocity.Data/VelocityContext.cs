using Microsoft.EntityFrameworkCore;
using Velocity.Data.Models;

namespace Velocity.Data
{
    public class VelocityContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Transit> Transits { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Velocity");
        }

        public DbSet<TEntity> GetDbSetFor<TEntity>()
            where TEntity : class
        {
            DbSet<TEntity> entity = this.Set<TEntity>();
            return entity;
        }
    }
}
