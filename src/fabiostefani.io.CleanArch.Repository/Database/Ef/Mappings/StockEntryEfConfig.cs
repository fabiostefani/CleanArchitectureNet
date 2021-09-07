using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fabiostefani.io.CleanArch.Repository.Database.Ef.Mappings
{
    public class StockEntryEfConfig : IEntityTypeConfiguration<StockEntryEf>
    {
        public void Configure(EntityTypeBuilder<StockEntryEf> builder)
        {
            builder.ToTable("stock_entry");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

            builder.Property(x => x.IdItem)
            .HasColumnName("id_item")
            .IsRequired();

            builder.Property(x => x.Operation)
            .HasColumnName("operation")
            .IsRequired()
            .HasMaxLength(5);

            builder.Property(x => x.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

            builder.Property(x => x.Date)
            .HasColumnName("date")
            .IsRequired();
        }
    }
}