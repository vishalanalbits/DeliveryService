using Microsoft.EntityFrameworkCore;
using Delivery.Service.Data.Models;

namespace Delivery.Service.Data.Contexts
{
    public class DeliveryDbContext : DbContext
    {
        public DbSet<Deliverys> Deliverys { get; set; }

        public DeliveryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryDbContext).Assembly);

            modelBuilder.Entity<Deliverys>().ToTable("Delivery");
        }
    }
}
