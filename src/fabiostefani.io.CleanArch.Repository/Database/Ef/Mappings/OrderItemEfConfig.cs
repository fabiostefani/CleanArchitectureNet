using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fabiostefani.io.CleanArch.Repository.Database.Ef.Mappings
{
    public class OrderItemEfConfig : IEntityTypeConfiguration<OrderItemEf>
    {
        public void Configure(EntityTypeBuilder<OrderItemEf> builder)
        {
            builder.ToTable("order_item");

            builder.HasKey(x => new {x.OrderId, x.ItemId});

            builder.Property(x => x.OrderId)
            .HasColumnName("id_order")
            .IsRequired();

            builder.Property(x => x.ItemId)
            .HasColumnName("id_item")
            .IsRequired();

            builder.Property(x => x.Price)
            .HasColumnName("price")
            .HasPrecision(15, 2)
            .IsRequired();

            builder.Property(x => x.Quantity)
            .HasColumnName("quantity")            
            .IsRequired();
        }
    }
}