using fabiostefani.io.CleanArch.Repository.Database.Ef.ModelEf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fabiostefani.io.CleanArch.Repository.Database.Ef.Mappings
{
    public class TaxTableEfConfig : IEntityTypeConfiguration<TaxTableEf>
    {
        public void Configure(EntityTypeBuilder<TaxTableEf> builder)
        {
            builder.ToTable("tax_table");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id)
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

            builder.Property(x => x.CodigoItem)
            .HasColumnName("id_item")
            .IsRequired();

            builder.Property(x => x.Type)
            .HasColumnName("type")
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(x => x.Value)
            .HasColumnName("value")
            .IsRequired();
        }
    }
}