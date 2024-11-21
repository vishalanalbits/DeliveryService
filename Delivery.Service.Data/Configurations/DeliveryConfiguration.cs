using Delivery.Service.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Service.Data.Configurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Deliverys>
    {
        public void Configure(EntityTypeBuilder<Deliverys> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.Username).IsUnique();

            builder.Property(x => x.Password).IsRequired().HasMaxLength(60);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(254);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.IsAvailable).IsRequired().HasDefaultValue(false);

            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);

            builder.Property(x => x.Vehical).IsRequired().HasMaxLength(50);
        }
    }
}
